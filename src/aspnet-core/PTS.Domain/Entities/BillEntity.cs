using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PTS.Domain.Entities
{
    [Table("Bill")]
    public class BillEntity : BaseEntity
    {
      
        [Required]
        [MaxLength(100)]
        public string? InvoiceCode { get; set; }
        [MaxLength(20)]
        public string? PhoneNumber { get; set; }
        [MaxLength(150)]
        public string? FullName { get; set; }
        [MaxLength(150)]
        public string? Address { get; set; }
        public int Payment { get; set; }
        public bool IsPayment { get; set; }
        public decimal? Discount { get; set; }
        public int? VoucherId { get; set; }
        public int? UserId { get; set; }
        public virtual VoucherEntity? VoucherEntitity { get; set; }
        public virtual UserEntity? UserEntity { get; set; }
        public virtual ICollection<BillDetailEntity>? BillDetailEntities { get; set; }


    }
}
