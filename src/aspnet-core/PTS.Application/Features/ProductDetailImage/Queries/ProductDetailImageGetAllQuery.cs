using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PTS.Application.Features.ProductDetailImages.DTOs;
using PTS.Application.Interfaces.Repositories;
using PTS.Core.Enums;
using PTS.Domain.Entities;
using PTS.Shared;

namespace PTS.Application.Features.ProductDetailImages.Queries
{
    public record ProductDetailImageGetAllQuery : IRequest<Result<List<ProductDetailImageDto>>>
	{
    }
	internal class ProductDetailImageGetAllQueryHandler : IRequestHandler<ProductDetailImageGetAllQuery, Result<List<ProductDetailImageDto>>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
        public ProductDetailImageGetAllQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
        }
		public async Task<Result<List<ProductDetailImageDto>>> Handle(ProductDetailImageGetAllQuery queryInput, CancellationToken cancellationToken)
		{
			var result = await _unitOfWork.Repository<ProductDetailImage>().Entities
				.AsNoTracking()
				.Where(x => x.Status != (int)StatusEnum.Delete)
				.ProjectTo<ProductDetailImageDto>(_mapper.ConfigurationProvider)
				.ToListAsync(cancellationToken);
			return await Result<List<ProductDetailImageDto>>.SuccessAsync(result);
		}
	}
}
