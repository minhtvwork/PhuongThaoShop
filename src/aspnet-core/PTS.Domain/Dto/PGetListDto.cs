﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTS.Domain.Dto
{
   public class PGetListDto
    {
        public string? ProductType { get; set; }
        public int? GetNumber { get; set; } = 5;
        public string? SortBy { get; set;}
        public string? Search { get; set; }

    }
}
