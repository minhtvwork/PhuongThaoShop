using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PTS.Domain.Entities
{
    [Table("SanPhamGiamGia")]
    public class SanPhamGiamGiaEntity : BaseEntity
    {
        [Key]
        public double DonGia { get; set; }
        public double SoTienConLai { get; set; }
        public int TrangThai { get; set; }
        public Guid ProductDetailId { get; set; }
        public Guid GiamGiaId { get; set; }
        public virtual GiamGiaEntity? GiamGia { get; set; }
        public virtual ProductDetailEntity? ProductDetail { get; set; }
    }
}
