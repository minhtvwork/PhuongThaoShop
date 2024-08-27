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
    public record ManufacturerGetAllQuery : IRequest<Result<List<ManufacturerDto>>>
	{
    }
	internal class ManufacturerGetAllQueryHandler : IRequestHandler<ManufacturerGetAllQuery, Result<List<ManufacturerDto>>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
        public ManufacturerGetAllQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
        }
		public async Task<Result<List<ManufacturerDto>>> Handle(ManufacturerGetAllQuery queryInput, CancellationToken cancellationToken)
		{
			var result = await _unitOfWork.Repository<ManufacturerEntity>().Entities
				.AsNoTracking()
				.Where(x => x.Status != (int)StatusEnum.Delete)
				.ProjectTo<ManufacturerDto>(_mapper.ConfigurationProvider)
				.ToListAsync(cancellationToken);
			return await Result<List<ManufacturerDto>>.SuccessAsync(result);
		}
	}
}
