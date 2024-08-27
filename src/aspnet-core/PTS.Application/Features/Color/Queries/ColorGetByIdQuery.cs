using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PTS.Application.Features.Color.DTOs;
using PTS.Application.Interfaces.Repositories;
using PTS.Core.Enums;
using PTS.Domain.Entities;
using PTS.Shared;

namespace PTS.Application.Features.Color.Queries
{
    public record ColorGetByIdQuery : IRequest<Result<ColorDto>>
	{
		public int Id { get; set; }
	}
	internal class ColorGetByIdQueryHandler : IRequestHandler<ColorGetByIdQuery, Result<ColorDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		public ColorGetByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public async Task<Result<ColorDto>> Handle(ColorGetByIdQuery queryInput, CancellationToken cancellationToken)
		{
			var result = await _unitOfWork.Repository<ColorEntity>().Entities
				  .AsNoTracking()
				.Where(x => x.Id == queryInput.Id && x.Status != (int)StatusEnum.Delete)
				.ProjectTo<ColorDto>(_mapper.ConfigurationProvider)
				.FirstOrDefaultAsync(cancellationToken);
			return await Result<ColorDto>.SuccessAsync(result);
		}
	}
}
