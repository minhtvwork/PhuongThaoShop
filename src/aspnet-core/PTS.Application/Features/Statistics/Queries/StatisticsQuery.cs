using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PTS.Application.Features.Bill.DTOs;
using PTS.Application.Features.BillDetail.DTOs;
using PTS.Application.Features.GetBestSellers.DTOs;
using PTS.Application.Features.Statistics.DTOs;
using PTS.Application.Interfaces.Repositories;
using PTS.Core.Enums;
using PTS.Domain.Entities;
using PTS.Shared;

namespace PTS.Application.Features.Statistics.Queries
{
    public record StatisticsQuery : IRequest<Result<StatisticsDto>>
    {
    }
    internal class StatisticsQueryHandler : IRequestHandler<StatisticsQuery, Result<StatisticsDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public StatisticsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<StatisticsDto>> Handle(StatisticsQuery queryInput, CancellationToken cancellationToken)
        {
            StatisticsDto result = new StatisticsDto();
            var bestSellers = await (from bd in _unitOfWork.Repository<BillDetailEntity>().Entities
                                join b in _unitOfWork.Repository<BillEntity>().Entities
                                on bd.BillEntityId equals b.Id
                                where b.Status == 8 // Bill Complete
                                group new { bd, b } by bd.CodeProductDetail into g
                                select new GetBestSellersDto
                                {
                                    CodeProductDetail = g.Key,
                                    TotalSold = g.Sum(x => x.bd.Quantity),
                                })
                                .OrderByDescending(x => x.TotalSold)
                                .Take(10)
                                .ToListAsync(cancellationToken);
           result.listBetSellers = bestSellers;
            var totalRevenue = await (from bd in _unitOfWork.Repository<BillDetailEntity>().Entities
                                      join b in _unitOfWork.Repository<BillEntity>().Entities
                                      on bd.BillEntityId equals b.Id
                                      where b.Status == 8 // Bill Complete
                                      select bd.Quantity * bd.Price).SumAsync(cancellationToken);

            result.TotalRevenue = totalRevenue;
           int cancel =  _unitOfWork.Repository<BillEntity>().Entities.Where(x => x.Status == (int)BillStatusEnum.Cancelled).AsNoTracking().Count();
            int allBill = _unitOfWork.Repository<BillEntity>().Entities.Where(x => x.Status != (int)BillStatusEnum.Delete).AsNoTracking().Count();
            double cancellationPercentage = (double)cancel / allBill * 100;
            string cancellation = cancellationPercentage.ToString("0.00") + "%";
            result.Cancellation = cancellation;
            return await Result<StatisticsDto>.SuccessAsync(result);
        }

    }
}
