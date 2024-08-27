using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PTS.Shared.Dto;
using PTS.Application.Dto;
using PTS.Domain.Entities;
using PTS.Application.Interfaces.Repositories;
using System.Linq.Expressions;
using PTS.WebAPI.Controllers;
using PTS.Application.Features.Cpu.Commands;
using PTS.Application.Features.Cpu.Queries;

namespace PTS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CpuController : BaseController
    {
        public CpuController()
        {
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new CpuGetAllQuery()));
        }
        [HttpPost("GetPage")]
        public async Task<IActionResult> GetPage(CpuGetPageQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
        [HttpPost("GetById")]
        public async Task<IActionResult> GetById(CpuGetByIdQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
        [HttpPost("CreateOrUpdate")]
        public async Task<IActionResult> CreateOrUpdate(CpuCreateOrUpdateCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(CpuDeleteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
