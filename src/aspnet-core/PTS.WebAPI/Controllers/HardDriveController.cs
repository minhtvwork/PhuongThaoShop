using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTS.Application.Dto;
using PTS.Domain.Entities;
using PTS.Application.Interfaces.Repositories;
using PTS.Shared.Dto;
using PTS.Application.Features.HardDrive.Commands;
using PTS.Application.Features.HardDrive.Queries;

namespace PTS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HardDriveController : BaseController
    {
        public HardDriveController()
        {
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new HardDriveGetAllQuery()));
        }
        [HttpPost("GetPage")]
        public async Task<IActionResult> GetPage(HardDriveGetPageQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
        [HttpPost("GetById")]
        public async Task<IActionResult> GetById(HardDriveGetByIdQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
        [HttpPost("CreateOrUpdate")]
        public async Task<IActionResult> CreateOrUpdate(HardDriveCreateOrUpdateCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(HardDriveDeleteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
