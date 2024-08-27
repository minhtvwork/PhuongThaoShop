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
    public record ColorGetAllQuery : IRequest<Result<List<ColorDto>>>
	{
    }
	internal class ColorGetAllQueryHandler : IRequestHandler<ColorGetAllQuery, Result<List<ColorDto>>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
        public ColorGetAllQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
        }
		public async Task<Result<List<ColorDto>>> Handle(ColorGetAllQuery queryInput, CancellationToken cancellationToken)
		{
			var result = await _unitOfWork.Repository<ColorEntity>().Entities
				.AsNoTracking()
				.Where(x => x.Status != (int)StatusEnum.Delete)
				.ProjectTo<ColorDto>(_mapper.ConfigurationProvider)
				.ToListAsync(cancellationToken);
			return await Result<List<ColorDto>>.SuccessAsync(result);
		}
	}
}
