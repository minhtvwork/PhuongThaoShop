using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PTS.Domain.Entities
{
    [Table("Image")]
    public class ImageEntity : BaseEntity
    {
        public string? Ma { get; set; }
        [MaxLength(150)]
        public string? LinkImage { get; set; }
        public int? ProductDetailId { get; set; }
        public virtual ProductDetailEntity? ProductDetailEntity { get; set; }
    }
}
