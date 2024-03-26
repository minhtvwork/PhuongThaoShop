﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTS.Domain.Dto;
using PTS.Domain.Entities;
using PTS.EntityFrameworkCore.Repository.IRepository;

namespace PTS.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : PTSBaseController
    {
        private readonly IProductRepository _productRepository;
        private readonly IConfiguration _config;
        private readonly ResponseDto _response;
        private readonly IPagingRepository _iPagingRepository;

        public ProductController(IProductRepository Ipr, IConfiguration config, IPagingRepository pagingRepository)
        {
            _productRepository = Ipr;
            _config = config;
            _response = new ResponseDto();
            _iPagingRepository = pagingRepository;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllPro()
        {
            string apiKey = _config.GetSection("ApiKey").Value;
            if (apiKey == null)
            {
                return Unauthorized();
            }

            var keyDomain = Request.Headers["Key-Domain"].FirstOrDefault();
            if (keyDomain != apiKey.ToLower())
            {
                return Unauthorized();
            }
            return Ok(await _productRepository.GetAll());
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(ProductEntity obj)
        {
            string apiKey = _config.GetSection("ApiKey").Value;
            if (apiKey == null)
            {
                return Unauthorized();
            }

            var keyDomain = Request.Headers["Key-Domain"].FirstOrDefault();
            if (keyDomain != apiKey.ToLower())
            {
                return Unauthorized();
            }
            if (await _productRepository.Create(obj))
            {
                return Ok("Thêm thành công");
            }
            return BadRequest("Thêm thất bại");
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductEntity x)
        {
            string apiKey = _config.GetSection("ApiKey").Value;
            if (apiKey == null)
            {
                return Unauthorized();
            }
            var keyDomain = Request.Headers["Key-Domain"].FirstOrDefault();
            if (keyDomain != apiKey.ToLower())
            {
                return Unauthorized();
            }
            if (await _productRepository.Update(x))
            {
                return Ok("Sửa thành công");
            }
            return BadRequest("Sửa thất bại");
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {

            string apiKey = _config.GetSection("ApiKey").Value;
            if (apiKey == null)
            {
                return Unauthorized();
            }

            var keyDomain = Request.Headers["Key-Domain"].FirstOrDefault();
            if (keyDomain != apiKey.ToLower())
            {
                return Unauthorized();
            }
            if (await _productRepository.Delete(id))
            {
                return Ok("Xóa thành công");
            }
            return BadRequest("Xóa thất bại");

        }
        [HttpGet("ProductById")]
        public async Task<IActionResult> ProductById(int id)
        {

            //    string apiKey = _config.GetSection("ApiKey").Value;
            //    if (apiKey == null)
            //    {
            //        return Unauthorized();
            //    }

            //    var keyDomain = Request.Headers["Key-Domain"].FirstOrDefault();
            //    if (keyDomain != apiKey.ToLower())
            //    {
            //        return Unauthorized();
            //    }
            return Ok(await _productRepository.GetById(id));
        }

        [HttpGet("GetProductFSP")]
        public async Task<IActionResult> GetProductFSP(string? search, decimal? from, decimal? to, string? sortBy, int page)
        {
            //string apiKey = _config.GetSection("ApiKey").Value;
            //if (apiKey == null)
            //{
            //    return Unauthorized();
            //}

            //var keyDomain = Request.Headers["Key-Domain"].FirstOrDefault();
            //if (keyDomain != apiKey.ToLower())
            //{
            //    return Unauthorized();
            //}
            //_response.Result = _iPagingRepository.GetProductDtos(search, from, to, sortBy, page);
            //_response.Count = _iPagingRepository.GetProductDtos(search, from, to, sortBy, page).Count;

            _response.Result = await _productRepository.GetProductDtos(search, from, to, sortBy, page);
            _response.Count = _productRepository.GetProductDtos(search, from, to, sortBy, page).Result.Count();
            return Ok(_response);
        }

    }
}
