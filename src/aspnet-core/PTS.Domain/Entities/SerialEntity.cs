using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PTS.Domain.Entities
{
    [Table("Serial")]
    public class SerialEntity : BaseEntity
    {
        [Required]
        public string? SerialNumber { get; set; }
        public int? ProductDetailId {  get; set; }
        public int? BillDetailId { get; set; }
        public virtual ProductDetailEntity? ProductDetailEntities { get; set; }
        public virtual BillDetailEntity? BillDetailEntities { get; set; }
    }
}
