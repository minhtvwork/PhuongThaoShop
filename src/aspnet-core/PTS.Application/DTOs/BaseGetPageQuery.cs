﻿using System.ComponentModel;

namespace IC.Application.DTOs
{
    public record BaseGetPageQuery
    {
        [DisplayName("Từ khóa")]
        public string Keywords { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
