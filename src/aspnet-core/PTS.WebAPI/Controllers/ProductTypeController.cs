
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTS.Shared.Dto;
using PTS.Application.Dto;
using PTS.Domain.Entities;
using PTS.Application.Interfaces.Repositories;
using PTS.Application.Features.ProductType.Commands;
using PTS.Application.Features.ProductType.Queries;
namespace PTS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : BaseController
    {
        public ProductTypeController()
        {
        }
        [Authorize(Policy = "AdminPolicy")]
        //[Authorize(Roles = "Admin")]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new ProductTypeGetAllQuery()));

        }
       /// [Authorize(Roles = "Admin")]
        [Authorize(Policy = "AdminPolicy")]
        [HttpPost("GetPage")]
        public async Task<IActionResult> GetPage(ProductTypeGetPageQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
        [HttpPost("GetById")]
        public async Task<IActionResult> GetById(ProductTypeGetByIdQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
        [HttpPost("CreateOrUpdate")]
        public async Task<IActionResult> CreateOrUpdate(ProductTypeCreateOrUpdateCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(ProductTypeDeleteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
