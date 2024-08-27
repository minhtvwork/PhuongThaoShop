
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PTS.Application.Features.IdentityFeatures.Users.Commands;
using PTS.Application.Features.IdentityFeatures.Users.Queries;

namespace PTS.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
    public class UserController : BaseController
    {
        public UserController()
        {

        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new UserGetAllQuery()));
        }
        [HttpPost("GetById")]
        public async Task<IActionResult> GetById(UserGetByIdQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        //[HttpPost("GetPage")]
        //public async Task<IActionResult> GetPage(UserGetPageQuery query)
        //{
        //	return Ok(await _mediator.Send(query));
        //}
        [HttpPost("CreateOrUpdate")]
        public async Task<IActionResult> CreateOrUpdate(UserEditCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        //[HttpPost("Delete")]
        //public async Task<IActionResult> Delete(UserDeleteCommand command)
        //{
        //    return Ok(await Mediator.Send(command));
        //}
    }
}
