using PTS.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PTS.Domain.Entities
{
    [Table("ProductDetail")]
    public class ProductDetailEntity : BaseAuditableEntity
    {
        [Key]
		public int Id { get; set; }
		[Required]
        [MaxLength(50)]
        public string Code { get; set; }
        public Decimal Price { get; set; }
        public Decimal OldPrice { get; set; }
		public string? Image1 { get; set; }
		public string? Image2 { get; set; }
		public string? Image3 { get; set; }
		public string? Image4 { get; set; }
		public string? Image5 { get; set; }
		public string? Image6 { get; set; }
		public string? Upgrade { get; set; }
        public string? Description { get; set; }
        public int ProductEntityId { get; set; }
        public int? ColorEntityId { get; set; }
        public int? RamEntityId { get; set; }
        public int? CpuEntityId { get; set; }
        public int? HardDriveEntityId { get; set; }
        public int? ScreenEntityId { get; set; }
        public int? CardVGAEntityId { get; set; }
		public int? CrUserId { get; set; }
		public DateTime? CrDateTime { get; set; }
		public int Status { get; set; }
        [NotMapped]
		public virtual ColorEntity? ColorEntity { get; set; }
        [NotMapped]
        public virtual RamEntity? RamEntity { get; set; }
        [NotMapped]
        public virtual CpuEntity? CpuEntity { get; set; }
        [NotMapped]
        public virtual ScreenEntity? ScreenEntity { get; set; }
        [NotMapped]
        public virtual CardVGAEntity? CardVGAEntity { get; set; }
        [NotMapped]
        public virtual HardDriveEntity? HardDriveEntity { get; set; }
        [NotMapped]
        public virtual ProductEntity? ProductEntity { get; set; }
        [NotMapped]
        public ICollection<CartDetailEntity>? CartDetailEntities { get; set; }
        [NotMapped]
        public ICollection<SerialEntity>? SerialEntities { get; set; }
    }
}
