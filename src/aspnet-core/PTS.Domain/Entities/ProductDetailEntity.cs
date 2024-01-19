using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PTS.Domain.Entities
{
    [Table("ProductDetail")]
    public class ProductDetailEntity : BaseEntity
    {
      
        [Required]
        [MaxLength(50)]
        public string? Code { get; set; }
        public Decimal Price { get; set; }
        public Decimal OldPrice { get; set; }
        public string? Upgrade { get; set; }
        public string? Description { get; set; }
        public int ProductId { get; set; }
        public int? ColorId { get; set; }
        public int? RamId { get; set; }
        public int? CpuId { get; set; }
        public int? HardDriveId { get; set; }
        public int? ScreenId { get; set; }
        public int? CardVGAId { get; set; }
        public virtual ColorEntity? ColorEntity { get; set; }
        public virtual RamEntity? RamEntity { get; set; }
        public virtual CpuEntity? CpuEntity { get; set; }
        public virtual ScreenEntity? ScreenEntity { get; set; }
        public virtual CardVGAEntity? CardVGAEntity { get; set; }
        public virtual HardDriveEntity? HardDriveEntity { get; set; }
        public virtual ProductEntity? ProductEntity { get; set; }
        public ICollection<ImageEntity>? ImageEntities { get; set; }
        public ICollection<CartDetailEntity>? CartDetailEntities { get; set; }
        public ICollection<SerialEntity>? SerialEntities { get; set; }
    }
}
