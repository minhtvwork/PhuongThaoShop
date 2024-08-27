using AutoMapper;
using AutoMapper.QueryableExtensions;
using PTS.Application.DTOs;
using PTS.Application.Extensions;
using MediatR;
using PTS.Application.Interfaces.Repositories;
using PTS.Domain.Entities;
using PTS.Shared;
using PTS.Application.Features.Cpu.DTOs;
using PTS.Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace PTS.Application.Features.Cpu.Queries
{
    public record CpuGetPageQuery : BaseGetPageQuery, IRequest<PaginatedResult<CpuDto>>
    {
     
    }
    internal class CpuGetPagesQueryHandler : IRequestHandler<CpuGetPageQuery, PaginatedResult<CpuDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CpuGetPagesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<PaginatedResult<CpuDto>> Handle(CpuGetPageQuery queryInput, CancellationToken cancellationToken)
        {
            var query = from listObj in _unitOfWork.Repository<CpuEntity>().Entities.Where(x =>x.Status != (int)StatusEnum.Delete).AsNoTracking() select listObj;
            if (!string.IsNullOrEmpty(queryInput.Keywords))
            {
                query = query.Where(x => x.Ma.Contains(queryInput.Keywords));
            }
            query = query.OrderBy(x => x.CrDateTime);
            var pQuery = query.ProjectTo<CpuDto>(_mapper.ConfigurationProvider);
            var result = await pQuery.ToPaginatedListAsync(queryInput.Page, queryInput.PageSize, cancellationToken);
            if (result.Data != null && result.Data.Any())
            {
                int index = (queryInput.Page - 1) * queryInput.PageSize + 1;
                foreach (var item in result.Data)
                {
                    item.Stt = index++;
                }
            }
            return result;
        }
    }
}
