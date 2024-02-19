using System.ComponentModel.DataAnnotations;

namespace PTS.Domain.Dto
{
    public class RoleUpdateDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? normalizedName { get; set; }

        public string? concurrencyStamp { get; set; }
        public int status { get; set; }
    }
}