
using PTS.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PTS.Domain.Entities
{
    [Table("Role")]
    public class RoleEntity : BaseAuditableEntity
	{
        [Key]
		public int Id { get; set; }
		public string? RoleCode { get; set; }
        public string? RoleName { get; set; }
		public int? CrUserId { get; set; }
		public DateTime? CrDateTime { get; set; }
		public int Status { get; set; }
		[NotMapped]
		public virtual ICollection<UserEntity>? UserEntities { get; set; }
    }
}
