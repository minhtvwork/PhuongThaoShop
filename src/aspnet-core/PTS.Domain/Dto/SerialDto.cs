using PTS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTS.Domain.Dto
{
    public class SerialDto
    {
        public int Id { get; set; }
        public string? SerialNumber { get; set; }
        public int Status { get; set; }
        public int? ProductDetailId { get; set; }// Tạo khóa ngoại
        public string? ProductDetailCode { get; set; }
        public int? BillDetailId { get; set; }// Tạo khóa ngoại
        public string? BillDetailCode { get; set; }
        
    }
}
