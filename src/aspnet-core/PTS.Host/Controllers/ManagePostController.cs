﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTS.Domain.Dto;
using PTS.Domain.Entities;
using PTS.EntityFrameworkCore.Repository.IRepository;
namespace PTS.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagePostController : PTSBaseController
    {
        private readonly IManagePostRepository _mpRepository;
        private readonly IConfiguration _config;
        private readonly ResponseDto _response;


        public ManagePostController(IManagePostRepository mpRepository, IConfiguration config)
        {
            _mpRepository = mpRepository;
            _config = config;
            _response = new ResponseDto();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMPs()
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
            return Ok(await _mpRepository.GetAllManagePosts());
        }
        [HttpPost("CreateMP")]
        public async Task<IActionResult> CreateMP(ManagePostEntity obj)
        {

            //string apiKey = _config.GetSection("ApiKey").Value;
            ////if (apiKey == null)
            ////{
            ////    return Unauthorized();
            ////}

            ////var keyDomain = Request.Headers["Key-Domain"].FirstOrDefault();
            ////if (keyDomain != apiKey.ToLower())
            ////{
            ////    return Unauthorized();
            ////}
            if (await _mpRepository.Create(obj))
            {
                return Ok("Thêm thành công");
            }
            return BadRequest("Thêm thất bại");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMP(ManagePostEntity obj)
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
            if (await _mpRepository.Update(obj))
            {
                return Ok("Sửa thành công");
            }
            return BadRequest("Sửa thất bại");
        }
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteMP(int id)
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
            if (await _mpRepository.Delete(id))
            {
                return Ok("Xóa thành công");
            }
            return BadRequest("Xóa thất bại");
        }
        [AllowAnonymous]
        [HttpGet("GetByIdManagePost")]
        public async Task<IActionResult> GetByIdManagePost(int id)
        {
            //string apiKey = _config.GetSection("ApiKey").Value;
            //if (apiKey == null)
            //{
            //    return Unauthorized();
            //}
            //string keyDomain = Request.Headers["Key-Domain"].FirstOrDefault();
            //if (keyDomain != apiKey.ToLower())
            //{
            //    return Unauthorized();
            //}
            var result = await _mpRepository.GetById(id);

            if (result != null)
            {
                return Ok(result);
            }
            else { return BadRequest("Không tìm thấy"); };
        }

        [HttpGet("GetAllReturnReposon")]
        public async Task<IActionResult> GetAllReturnReposon()
        {
            _response.Result = await _mpRepository.GetAllManagePosts();
            _response.Count = _mpRepository.GetAllManagePosts().Result.Count();
            return Ok(_response);
        }
        [AllowAnonymous]
        [HttpGet("GGetManagePostDtosFSP")]
        public async Task<IActionResult> GGetManagePostDtosFSP(string? search, DateTime? from, DateTime? to, string? sortBy, bool? status, int page)
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

            _response.Result = await _mpRepository.GetManagePostDtos(search, from, to, sortBy,status, page);
            _response.Count = _mpRepository.GetManagePostDtos(search, from, to, sortBy,status, page).Result.Count();
            return Ok(_response);
        }


        [HttpPut("Duyet")]
        public async Task<IActionResult> Duyet(int id)
        {      
            var response = await _mpRepository.Duyet(id);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("HuyDuyet")]
        public async Task<IActionResult> HuyDuyet(int id)
        {
            var response = await _mpRepository.HuyDuyet(id);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

    }
}
