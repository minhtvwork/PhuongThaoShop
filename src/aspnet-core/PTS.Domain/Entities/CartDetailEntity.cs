using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PTS.Domain.Entities
{
    [Table("CartDetail")]
    public class CartDetailEntity : BaseEntity
    {
        public int CartId { get; set; }
        public int ProductDetailEntityId { get; set; }
        public int Quantity { get; set; }
        public virtual CartEntity? CartEntity { get; set; }
        public virtual ProductDetailEntity? ProductDetailEntity { get; set; }


    }
}
