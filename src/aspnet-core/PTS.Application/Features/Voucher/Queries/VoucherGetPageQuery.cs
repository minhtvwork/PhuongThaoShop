using AutoMapper;
using AutoMapper.QueryableExtensions;
using IC.Application.DTOs;
using IC.Application.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PTS.Application.Features.ProductDetail.Queries;
using PTS.Core.Repositories;
using PTS.Domain.Entities;
using PTS.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IC.Application.Features.PhapDienDocs.Fields.Queries
{
    public record VoucherGetPageQuery : BaseGetPageQuery, IRequest<PaginatedResult<VoucherDto>>
    {
     
    }
    internal class VoucherGetPagesQueryHandler : IRequestHandler<VoucherGetPageQuery, PaginatedResult<VoucherDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ISender _sender;
        public VoucherGetPagesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper,ISender sender)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _sender = sender;
        }
        public async Task<PaginatedResult<VoucherDto>> Handle(VoucherGetPageQuery queryInput, CancellationToken cancellationToken)
        {
            var query = from listObj in _unitOfWork.Repository<VoucherEntity>().Entities.AsNoTracking() select listObj;
            if (!string.IsNullOrWhiteSpace(queryInput.Keywords))
            {
                query = query.Where(a => a.MaVoucher.Contains(queryInput.Keywords));
            }
            //query = query.OrderBy(x => x.DisplayOrder);
            var pQuery = query.ProjectTo<VoucherDto>(_mapper.ConfigurationProvider);
            var result = await pQuery.ToPaginatedListAsync(queryInput.Page, queryInput.PageSize, cancellationToken);
            return result;
        }
    }
}
