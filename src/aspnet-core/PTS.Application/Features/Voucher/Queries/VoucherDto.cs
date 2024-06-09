using Nest;
using PTS.Application.Common.Mappings;
using PTS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PTS.Application.Features.ProductDetail.Queries
{
	public class VoucherDto : IMapFrom<VoucherEntity>
	{
		public int Id { get; set; }
		public DateTime? CreationTime { get; set; } = DateTime.Now;
		public bool IsDeleted { get; set; } = false;
		public int? Status { get; set; } = 1;
		[MaxLength(50)]
		public string? MaVoucher { get; set; }
		[MaxLength(150)]
		public string? TenVoucher { get; set; }
		public DateTime? StarDay { get; set; }
		public DateTime? EndDay { get; set; }
		public decimal GiaTri { get; set; }
		public int SoLuong { get; set; }

	}
}
