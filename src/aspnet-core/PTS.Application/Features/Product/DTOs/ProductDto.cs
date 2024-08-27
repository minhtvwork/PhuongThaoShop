using PTS.Application.Common.Mappings;
using PTS.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PTS.Application.Features.Product.DTOs
{
    public class ProductDto : IMapFrom<ProductEntity>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ManufacturerName { get; set; }
        public string ProductTypeName { get; set; } 
        public int? CrUserId { get; set; }
        public DateTime? CrDateTime { get; set; }
        public int Status { get; set; }
        public int? ManufacturerEntityId { get; set; }
        public int? ProductTypeEntityId { get; set; }
        public int Stt {  get; set; }   
    }
}
