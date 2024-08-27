using PTS.Application.Common.Mappings;
using PTS.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PTS.Application.Features.GetBestSellers.DTOs
{
    public class GetBestSellersDto 
    {
        public string CodeProductDetail { get; set; } 
        public int TotalSold { get; set; }
    }
}
