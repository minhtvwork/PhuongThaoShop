using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using PTS.Application.Common.Mappings;
using PTS.Application.Features.IdentityFeatures.Users.Queries;
using PTS.Domain.Entities;
using PTS.Shared;

namespace PTS.Application.Features.IdentityFeatures.Users.Queries
{
    public record UserGetByIdQuery : IRequest<Result<UserGetByIdDto>>, IMapFrom<UserGetByIdDto>
	{
		public int Id { get; set; }
	}

	internal class UserGetByIdQueryHandler : IRequestHandler<UserGetByIdQuery, Result<UserGetByIdDto>>
	{
		private readonly IMapper _mapper;
		private readonly UserManager<UserEntity> _userManager;
		public UserGetByIdQueryHandler(IMapper mapper, UserManager<UserEntity> userManager)
		{
			_mapper = mapper;
			_userManager = userManager;
		}

		public async Task<Result<UserGetByIdDto>> Handle(UserGetByIdQuery query, CancellationToken cancellationToken)
		{
			var userById = await _userManager.FindByIdAsync(query.Id.ToString());

			var userGetByIdDto = _mapper.Map<UserGetByIdDto>(userById);

			return await Result<UserGetByIdDto>.SuccessAsync(userGetByIdDto);
		}
	}
}
