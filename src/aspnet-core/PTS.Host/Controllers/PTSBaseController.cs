using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PTS.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize(Roles = "Admin")]
    public class PTSBaseController : ControllerBase
    {
    }
}
