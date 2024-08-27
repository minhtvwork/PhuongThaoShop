using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PTS.Application.Features.IdentityFeatures.Users.Queries;
using PTS.Domain.Entities;
using PTS.Shared;
namespace PTS.Application.Features.IdentityFeatures.Users.Queries
{
    public class UserGetAllQuery : IRequest<Result<List<UserGetAllDto>>>
    {
        public bool? IsEnabled { get; set; }
	}
    internal class UserGetAllQueryHandler : IRequestHandler<UserGetAllQuery, Result<List<UserGetAllDto>>>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<UserEntity> _userManager;

        public UserGetAllQueryHandler(IMapper mapper, UserManager<UserEntity> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<Result<List<UserGetAllDto>>> Handle(UserGetAllQuery request, CancellationToken cancellationToken)
        {
            var query = _userManager.Users.AsNoTracking();

            if (request.IsEnabled.HasValue)
            {
                query = query.Where(x => x.IsEnabled == request.IsEnabled);
			}

			var result = await query
				.OrderByDescending(x => x.Id)
                .ProjectTo<UserGetAllDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return await Result<List<UserGetAllDto>>.SuccessAsync(result);
        }
    }
}
