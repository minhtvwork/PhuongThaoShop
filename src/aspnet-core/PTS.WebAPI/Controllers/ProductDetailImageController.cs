using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTS.Shared.Dto;
using PTS.Application.Dto;
using PTS.Domain.Entities;
using PTS.Application.Interfaces.Repositories;
using PTS.Application.Features.ProductDetailImages.Commands;
using PTS.Application.Features.ProductDetailImages.Queries;

namespace PTS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailImageController : BaseController
    {
        public ProductDetailImageController()
        {

        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new ProductDetailImageGetAllQuery()));
        }
        [HttpPost("GetPage")]
        public async Task<IActionResult> GetPage(ProductDetailImageGetPageQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
        [HttpPost("GetById")]
        public async Task<IActionResult> GetById(ProductDetailImageGetByIdQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
        [HttpPost("CreateOrUpdate")]
        public async Task<IActionResult> CreateOrUpdate(ProductDetailImageCreateOrUpdateCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(ProductDetailImageDeleteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

    }
}
