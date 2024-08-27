using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PTS.Application.Features.Bill.DTOs;
using PTS.Application.Features.BillDetail.DTOs;
using PTS.Application.Interfaces.Repositories;
using PTS.Core.Enums;
using PTS.Domain.Entities;
using PTS.Shared;

namespace PTS.Application.Features.BillDetail.Queries
{
    public record BillGetByUserIdQuery : IRequest<Result<List<BillDto>>>
    {
        public int UserId { get; set; } 
    }
    internal class BillGetByUserIdQueryHandler : IRequestHandler<BillGetByUserIdQuery, Result<List<BillDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BillGetByUserIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<BillDto>>> Handle(BillGetByUserIdQuery queryInput, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Repository<BillEntity>().Entities
                .AsNoTracking()
                .Where(x => x.UserEntityId == queryInput.UserId)
                .ProjectTo<BillDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return await Result<List<BillDto>>.SuccessAsync(result);
        }
    }

}
