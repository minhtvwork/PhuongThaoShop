﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTS.Shared.Dto;
using PTS.Application.Dto;
using PTS.Domain.Entities;
using PTS.Application.Interfaces.Repositories;
using PTS.WebAPI.Controllers;
using PTS.Application.Features.ProductDetail.Commands;
using PTS.Application.Features.Voucher.Commands;
using PTS.Application.Features.ProductDetail.Queries;
using PTS.Application.Features.CardVGA.Commands;
namespace PTS.WebAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : BaseController
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IProductDetailRepository _repository;
        private readonly ResponseDto _reponse;
        private readonly IConfiguration _config;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ProductDetailController(IWebHostEnvironment environment, IProductDetailRepository repository, IConfiguration config, IMediator mediator, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _environment = environment;
            _repository = repository;
            _reponse = new ResponseDto();
            _config = config;
            _mediator = mediator;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            return Ok(await Mediator.Send(new ProductDetailGetAllQuery()));
        }
        [HttpPost("GetPage")]
        public async Task<IActionResult> GetPage(ProductDetailGetPageQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
        [AllowAnonymous]
        [HttpPost("GetCountById")]
        public async Task<IActionResult> GetCountById(ProductDetailGetCountByIdQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
        [AllowAnonymous]
        [HttpPost("PublicGetList")]
        public async Task<IActionResult> PublicGetList(GetProductDetailRequest request)
        {
            return Ok(await _unitOfWork._productDetailRepository.PublicGetList(request));
        }
        [AllowAnonymous]
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            _reponse.Result = await _unitOfWork._productDetailRepository.GetById(id);
            return Ok(_reponse);
        }
        [AllowAnonymous]
        [HttpGet("PGetProductDetail")]
        public async Task<IActionResult> PGetProductDetail(int? getNumber, string? codeProductDetail, int? status, string? search, decimal? from, decimal? to, string? sortBy, int? page, string? productType, string? hangsx, string? ram, string? CPU, string? cardVGA)
        {

            var listProductDetail = await _repository.PGetProductDetail(getNumber, codeProductDetail, status, search, from, to, sortBy, page, productType, hangsx, ram, CPU, cardVGA);
            _reponse.Result = listProductDetail;
            return Ok(_reponse);
        }
        [HttpPost("CreateOrUpdate")]
        public async Task<IActionResult> CreateOrUpdate(ProductDetailCreateOrUpdateCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(ProductDetailDeleteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPost("CreateMany")]
        public async Task<IActionResult> CreateMany(List<ProductDetailEntity> list)
        {

            return BadRequest("Lỗi");
        }
		//[HttpPost]
		//public async Task<ActionResult<CreateProductDetailDto>> PostProduct([FromForm] CreateProductDetailDto product, IFormFile[] files)
		//{
		//	if (files != null && files.Length > 0)
		//	{
		//		await SaveFiles(product, files);
		//	}

		

		//	return CreatedAtAction("GetProduct", new { id = product.Id }, product);
		//}
		//private async Task SaveFiles(CreateProductDetailDto product, IFormFile[] files)
  //      {
  //          string[] imageProperties = { "Image1", "Image2", "Image3", "Image4", "Image5", "Image6" };

  //          for (int i = 0; i < files.Length && i < imageProperties.Length; i++)
  //          {
  //              var file = files[i];
  //              if (file != null && file.Length > 0)
  //              {
  //                  var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
  //                  var filePath = Path.Combine(_environment.WebRootPath, "uploads", fileName);

  //                  using (var stream = new FileStream(filePath, FileMode.Create))
  //                  {
  //                      await file.CopyToAsync(stream);
  //                  }

  //                  typeof(CreateProductDetailDto).GetProperty(imageProperties[i])?.SetValue(product, $"/uploads/{fileName}");
  //              }
  //          }
  //      }
    }
}
