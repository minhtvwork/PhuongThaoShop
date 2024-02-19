using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTS.Domain.Dto
{
    public class TichDiemDto
    {
        public decimal TienTieuDiem { get; set; }
        public decimal TienTichDiem { get; set; }
        public decimal SoDiemDaDungTrongHoaDon { get; set; }
        public decimal SoDiemCongTrongHoaDon { get; set; }
        public DateTime NgaySD { get; set; }
        public decimal TongDiemTrongViDiem { get; set; }
        public decimal SoDiemDaCongTrongVi { get; set; }
        public decimal SoDiemDaDungTrongVi { get; set; }
        public int TrangThaiViDiem { get; set; }
       

    }
}
