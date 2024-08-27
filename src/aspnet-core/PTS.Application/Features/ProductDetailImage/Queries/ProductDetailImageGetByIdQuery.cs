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
    public record ProductDetailImageGetByIdQuery : IRequest<Result<ProductDetailImageDto>>
	{
		public int Id { get; set; }
	}
	internal class ProductDetailImageGetByIdQueryHandler : IRequestHandler<ProductDetailImageGetByIdQuery, Result<ProductDetailImageDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		public ProductDetailImageGetByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public async Task<Result<ProductDetailImageDto>> Handle(ProductDetailImageGetByIdQuery queryInput, CancellationToken cancellationToken)
		{
			var result = await _unitOfWork.Repository<ProductDetailImage>().Entities
				  .AsNoTracking()
				.Where(x => x.Id == queryInput.Id && x.Status != (int)StatusEnum.Delete)
				.ProjectTo<ProductDetailImageDto>(_mapper.ConfigurationProvider)
				.FirstOrDefaultAsync(cancellationToken);
			return await Result<ProductDetailImageDto>.SuccessAsync(result);
		}
	}
}
