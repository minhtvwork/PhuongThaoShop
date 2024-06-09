
using PTS.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PTS.Domain.Entities
{
    [Table("Voucher")]
    public class VoucherEntity : BaseAuditableEntity
    {

		public int Id { get; set; }
		public DateTime? CreationTime { get; set; } = DateTime.Now;
		public bool IsDeleted { get; set; } = false;
		public int? Status { get; set; } = 1;
		[MaxLength(50)]
        public string? MaVoucher { get; set; }
        [MaxLength(150)]
        public string? TenVoucher { get; set; }
        public DateTime? StarDay { get; set; }
        public DateTime? EndDay { get; set; }
        public decimal GiaTri { get; set; }
        public int SoLuong { get; set; }
        [NotMapped]
        public virtual ICollection<BillEntity>? BillEntities { get; set; }
    }
}
