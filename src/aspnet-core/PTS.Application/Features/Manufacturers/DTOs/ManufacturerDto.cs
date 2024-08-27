using PTS.Application.Common.Mappings;
using PTS.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PTS.Application.Features.Manufacturer.DTOs
{
    public class ManufacturerDto : IMapFrom<ManufacturerEntity>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? CrUserId { get; set; }
        public DateTime? CrDateTime { get; set; }
        public int Status { get; set; }
        public int Stt {  get; set; }   
    }
}
