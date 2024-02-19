using System.ComponentModel.DataAnnotations;

namespace PTS.Domain.Dto
{
    public class RoleCreateDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? normalizedName { get; set; }

        public string? concurrencyStamp { get; set; }
    }
}