using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PTS.Application.Features.Cpu.Queries;
using PTS.Application.Features.Statistics.Queries;

namespace PTS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : BaseController
    {
        [HttpGet("GetBestSellers")]
        public async Task<IActionResult> GetBestSellers()
        {
            return Ok(await Mediator.Send(new StatisticsQuery()));
        }
    }
}
