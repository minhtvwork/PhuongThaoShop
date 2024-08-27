using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PTS.Application.Features.Manufacturer.DTOs;
using PTS.Application.Interfaces.Repositories;
using PTS.Core.Enums;
using PTS.Domain.Entities;
using PTS.Shared;

namespace PTS.Application.Features.Manufacturer.Queries
{
    public record ManufacturerGetByIdQuery : IRequest<Result<ManufacturerDto>>
	{
		public int Id { get; set; }
	}
	internal class ManufacturerGetByIdQueryHandler : IRequestHandler<ManufacturerGetByIdQuery, Result<ManufacturerDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		public ManufacturerGetByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public async Task<Result<ManufacturerDto>> Handle(ManufacturerGetByIdQuery queryInput, CancellationToken cancellationToken)
		{
			var result = await _unitOfWork.Repository<ManufacturerEntity>().Entities
				  .AsNoTracking()
				.Where(x => x.Id == queryInput.Id && x.Status != (int)StatusEnum.Delete)
				.ProjectTo<ManufacturerDto>(_mapper.ConfigurationProvider)
				.FirstOrDefaultAsync(cancellationToken);
			return await Result<ManufacturerDto>.SuccessAsync(result);
		}
	}
}
