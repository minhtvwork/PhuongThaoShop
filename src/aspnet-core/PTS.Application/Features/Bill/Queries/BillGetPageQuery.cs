using AutoMapper;
using AutoMapper.QueryableExtensions;
using PTS.Application.DTOs;
using PTS.Application.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PTS.Application.Interfaces.Repositories;
using PTS.Domain.Entities;
using PTS.Shared;
using PTS.Application.Features.Bill.DTOs;
using PTS.Core.Enums;

namespace PTS.Application.Features.Bill.Queries
{
    public record BillGetPageQuery : BaseGetPageQuery, IRequest<PaginatedResult<BillGetPageDto>>
    {
     
    }
    internal class BillGetPagesQueryHandler : IRequestHandler<BillGetPageQuery, PaginatedResult<BillGetPageDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BillGetPagesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<PaginatedResult<BillGetPageDto>> Handle(BillGetPageQuery queryInput, CancellationToken cancellationToken)
        {
            var query = from listObj in _unitOfWork.Repository<BillEntity>().Entities.Where(x =>x.Status != (int)StatusEnum.Delete).AsNoTracking() select listObj;
            if (!string.IsNullOrEmpty(queryInput.Keywords))
            {
               // query = query.Where(x => x.Ma.Contains(queryInput.Keywords) || x.ThongSo.Contains(queryInput.Keywords));
            }
            query = query.OrderBy(x => x.CrDateTime);
            var pQuery = query.ProjectTo<BillGetPageDto>(_mapper.ConfigurationProvider);
            var result = await pQuery.ToPaginatedListAsync(queryInput.Page, queryInput.PageSize, cancellationToken);
            return result;
        }
    }
}
