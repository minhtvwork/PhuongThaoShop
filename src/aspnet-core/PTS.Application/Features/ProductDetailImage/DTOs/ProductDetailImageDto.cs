using PTS.Application.Common.Mappings;
using PTS.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PTS.Application.Features.ProductDetailImages.DTOs
{
    public class ProductDetailImageDto : IMapFrom<ProductDetailImage>
    {
        public int Id { get; set; }
        public int ProductDetailId { get; set; }
        public string CodeProductDetail { get; set; }    
        public string ImageName { get; set; }
        public string ImageUrl { get; set; }
        public bool IsIndex { get; set; }
        public int Status { get; set; }
        public int ImageId { get; set; }
        public int Stt {  get; set; }   
    }
}
