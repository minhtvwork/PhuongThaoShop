

using PTS.Application.Common.Mappings;
using PTS.Domain.Entities;

namespace PTS.Application.Features.IdentityFeatures.Users.Queries
{
	public class UserGetAllDto : IMapFrom<UserEntity>
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string DisplayName => !string.IsNullOrWhiteSpace(FullName) ? FullName : UserName;
    }
}
