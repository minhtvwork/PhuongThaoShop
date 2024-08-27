using PTS.Application.Features.GetBestSellers.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTS.Application.Features.Statistics.DTOs
{
    public class StatisticsDto
    {
       public List<GetBestSellersDto> listBetSellers { get; set; }
        public decimal TotalRevenue { get; set; }
        public string Cancellation {  get; set; }   
    }
}
