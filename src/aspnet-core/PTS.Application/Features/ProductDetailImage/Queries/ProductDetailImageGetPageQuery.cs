using AutoMapper;
using AutoMapper.QueryableExtensions;
using PTS.Application.DTOs;
using PTS.Application.Extensions;
using MediatR;
using PTS.Application.Interfaces.Repositories;
using PTS.Domain.Entities;
using PTS.Shared;
using PTS.Application.Features.ProductDetailImages.DTOs;
using PTS.Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace PTS.Application.Features.ProductDetailImages.Queries
{
    public record ProductDetailImageGetPageQuery : BaseGetPageQuery, IRequest<PaginatedResult<ProductDetailImageDto>>
    {
     
    }
    internal class ProductDetailImageGetPagesQueryHandler : IRequestHandler<ProductDetailImageGetPageQuery, PaginatedResult<ProductDetailImageDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductDetailImageGetPagesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<PaginatedResult<ProductDetailImageDto>> Handle(ProductDetailImageGetPageQuery queryInput, CancellationToken cancellationToken)
        {
            var query = from pdi in _unitOfWork.Repository<ProductDetailImage>().Entities.Where(x => x.Status != (int)StatusEnum.Delete).AsNoTracking()
                        join pd in _unitOfWork.Repository<ProductDetailEntity>().Entities.AsNoTracking() on pdi.ProductDetailId equals pd.Id
                        join img in _unitOfWork.Repository<ImageEntity>().Entities.AsNoTracking() on pdi.ImageId equals img.Id
                        select new ProductDetailImageDto
                        {
                            Id = pdi.Id,
                            ProductDetailId = pd.Id,
                            ImageId = img.Id,
                            CodeProductDetail = pd.Code,
                            ImageName = img.Name,
                            ImageUrl = img.Url,
                            Status = pdi.Status,
                            IsIndex = pdi.IsIndex,
                            Stt = 0 
                        };


            if (!string.IsNullOrEmpty(queryInput.Keywords))
            {
                query = query.Where(x => x.CodeProductDetail.Contains(queryInput.Keywords) || x.ImageName.Contains(queryInput.Keywords));
            }
            query = query.OrderBy(x => x.ProductDetailId);
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
