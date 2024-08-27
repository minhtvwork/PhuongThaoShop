using PTS.Application.Common.Mappings;
using PTS.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PTS.Application.Features.Color.DTOs
{
    public class ColorDto : IMapFrom<ColorEntity>
    {
        public int Id { get; set; }
        public string Ma { get; set; }
        public string Name { get; set; }
        public int? CrUserId { get; set; }
        public DateTime? CrDateTime { get; set; }
        public int Status { get; set; }
        public int Stt {  get; set; }   
    }
}
