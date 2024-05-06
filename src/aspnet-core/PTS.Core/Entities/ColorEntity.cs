using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PTS.Core.Entities
{
    [Table("Color")]
    public class ColorEntity : BaseEntity
    {
        public string? Ma { get; set; }
        [MaxLength(100)]
        public string? Name { get; set; }
        public virtual ICollection<ProductDetailEntity>? ProductDetailEntities { get; set; }
    }
}
