

using PTS.Application.Common.Mappings;
using PTS.Domain.Entities;

namespace PTS.Application.Features.IdentityFeatures.Users.Queries
{
    public class UserGetPageDto : UserDto, IMapFrom<UserEntity>
    { 
    }
}
