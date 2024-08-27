using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PTS.Application.Features.HardDrive.DTOs;
using PTS.Application.Interfaces.Repositories;
using PTS.Core.Enums;
using PTS.Domain.Entities;
using PTS.Shared;

namespace PTS.Application.Features.HardDrive.Queries
{
    public record HardDriveGetAllQuery : IRequest<Result<List<HardDriveDto>>>
	{
    }
	internal class HardDriveGetAllQueryHandler : IRequestHandler<HardDriveGetAllQuery, Result<List<HardDriveDto>>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
        public HardDriveGetAllQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
        }
		public async Task<Result<List<HardDriveDto>>> Handle(HardDriveGetAllQuery queryInput, CancellationToken cancellationToken)
		{
			var result = await _unitOfWork.Repository<HardDriveEntity>().Entities
				.AsNoTracking()
				.Where(x => x.Status != (int)StatusEnum.Delete)
				.ProjectTo<HardDriveDto>(_mapper.ConfigurationProvider)
				.ToListAsync(cancellationToken);
			return await Result<List<HardDriveDto>>.SuccessAsync(result);
		}
	}
}
