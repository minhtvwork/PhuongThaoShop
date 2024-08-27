using AutoMapper;
using AutoMapper.QueryableExtensions;
using PTS.Application.DTOs;
using PTS.Application.Extensions;
using MediatR;
using PTS.Application.Interfaces.Repositories;
using PTS.Domain.Entities;
using PTS.Shared;
using PTS.Application.Features.Product.DTOs;
using PTS.Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace PTS.Application.Features.Product.Queries
{
    public record ProductGetPageQuery : BaseGetPageQuery, IRequest<PaginatedResult<ProductDto>>
    {
     
    }
    internal class ProductGetPagesQueryHandler : IRequestHandler<ProductGetPageQuery, PaginatedResult<ProductDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductGetPagesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<PaginatedResult<ProductDto>> Handle(ProductGetPageQuery queryInput, CancellationToken cancellationToken)
        {
            var query = from product in _unitOfWork.Repository<ProductEntity>().Entities.Where(x => x.Status != (int)StatusEnum.Delete).AsNoTracking()
                        join manufacture in _unitOfWork.Repository<ManufacturerEntity>().Entities.AsNoTracking()
                        on product.ManufacturerEntityId equals manufacture.Id
                        join productType in _unitOfWork.Repository<ProductTypeEntity>().Entities.AsNoTracking()
                        on product.ProductTypeEntityId equals productType.Id
                        select new ProductDto
                        {
                            Id = product.Id,
                            Name = product.Name,
                            Status = product.Status,
                            ProductTypeEntityId = productType.Id,
                            ManufacturerEntityId = manufacture.Id,
                            CrDateTime = product.CrDateTime,
                            ManufacturerName = manufacture.Name,
                            ProductTypeName = productType.Name  
                                                               
                        };

            if (!string.IsNullOrEmpty(queryInput.Keywords))
            {
                query = query.Where(x => x.Name.Contains(queryInput.Keywords));
            }

            query = query.OrderBy(x => x.CrDateTime);
            var result = await query.ToPaginatedListAsync(queryInput.Page, queryInput.PageSize, cancellationToken);

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
