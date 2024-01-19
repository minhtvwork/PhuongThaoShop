using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PTS.Domain.Entities
{
    [Table("Cart")]
    public class CartEntity 
    {
        [Key, ForeignKey("UserEntity")]
        public int IdUser { get; set; }
        [MaxLength(200)]
        public string? Description { get; set; }
        public DateTime? CreationTime { get; set; }
        public bool IsDeleted { get; set; }
        public int? Status { get; set; }
        public virtual UserEntity? UserEntity { get; set; }
        public virtual ICollection<CartDetailEntity>? CartDetailEntities { get; set; }
    }
}
