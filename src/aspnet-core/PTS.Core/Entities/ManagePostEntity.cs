using System.ComponentModel.DataAnnotations.Schema;
namespace PTS.Core.Entities
{
    [Table("ManagePost")]
    public class ManagePostEntity: BaseEntity
    {
        public string? Code { get; set; }
        public string? LinkImage { get; set; }
        public string? Description { get; set; }
    }
}
