
using PTS.Application.Common.Mappings;
using PTS.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace PTS.Application.Features.IdentityFeatures.Users.Queries
{
	public class UserDto : IMapFrom<UserEntity>
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public string NormalizedUserName { get; set; }
		public string Email { get; set; }
		public string NormalizedEmail { get; set; }
		public bool EmailConfirmed { get; set; }
		public string PasswordHash { get; set; }
		public string SecurityStamp { get; set; }
		public string ConcurrencyStamp { get; set; }
		public string PhoneNumber { get; set; }
		public bool PhoneNumberConfirmed { get; set; }
		public bool TwoFactorEnabled { get; set; }
		public string FullName { get; set; }
		public string Address { get; set; }
		public DateTime? BirthDay { get; set; }
		public int? OrganId { get; set; }
		public int? DefaultActionId { get; set; }
		public string Notes { get; set; }
		public string AvatarPath { get; set; }
		public bool IsEnabled { get; set; }
	}
}
