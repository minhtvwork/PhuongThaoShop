using PTS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTS.Domain.Dto
{
   public class CpuDto : BaseEntity
    {
        public string? Ma { get; set; }
        [MaxLength(100)]
        public string? Ten { get; set; }
    }
}
