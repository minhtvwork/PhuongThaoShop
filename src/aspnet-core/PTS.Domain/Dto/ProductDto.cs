using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTS.Domain.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string? Name { get; set; }
        public int Status { get; set; }
        public string? ManuName { get; set; }
        public string? ProductTypeName { get; set; }
        public int? ManufacturerId { get; set; }
        public int? ProductTypeId { get; set; }
    }
}
