using System.ComponentModel.DataAnnotations;

namespace PTS.Core.Enums
{
	public enum StatusEnum
	{
		[Display(Name = "Dừng Hoạt động")]
		InActive = 1,

		[Display(Name = "Hoạt động")]
		Active = 2
	}
}
