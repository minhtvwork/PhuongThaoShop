using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PTS.Application.DTOs;
using PTS.Application.Extensions;
using PTS.Domain.Entities;
using PTS.Shared;
using System.ComponentModel;

namespace PTS.Application.Features.IdentityFeatures.Users.Queries
{
    public record UserGetPageQuery : BaseGetPageQuery, IRequest<PaginatedResult<UserGetPageDto>>
    {
        [DisplayName("Kích hoạt")]
        public byte IsEnabled { get; set; }

        [DisplayName("Xác thực 2 bước")]
        public byte TwoFactorEnabled { get; set; }
    }

    internal class UserGetPageQueryHandler : IRequestHandler<UserGetPageQuery, PaginatedResult<UserGetPageDto>>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<UserEntity> _userManager;

        public UserGetPageQueryHandler(IMapper mapper
          , UserManager<UserEntity> userManager
           )
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<PaginatedResult<UserGetPageDto>> Handle(UserGetPageQuery queryInput, CancellationToken cancellationToken)
        {

            var query = _userManager.Users;
            if (!string.IsNullOrEmpty(queryInput.Keywords))
            {
                query = query.Where(x => x.UserName.Contains(queryInput.Keywords) || x.FullName.Contains(queryInput.Keywords) || x.Email.Contains(queryInput.Keywords) || x.PhoneNumber.Contains(queryInput.Keywords));
            }
            var result = await query
                   .OrderByDescending(x => x.Id)
                   .ProjectTo<UserGetPageDto>(_mapper.ConfigurationProvider)
                   .ToPaginatedListAsync(queryInput.Page, queryInput.PageSize, cancellationToken);
            return result;
        }
    }
}
