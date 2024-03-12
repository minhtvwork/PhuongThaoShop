using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTS.Domain.Dto;
using PTS.Domain.Entities;
using PTS.EntityFrameworkCore.Repository.IRepository;

namespace PTS.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ColorController : ControllerBase
    {
        private readonly IColorRepository _colorRepository;
        private readonly IPagingRepository _iPagingRepository;
        private readonly IConfiguration _config;
        private readonly ResponseDto _reponse;
        public ColorController(IColorRepository colorRepository, IConfiguration config, IProductDetailRepository repository, IPagingRepository pagingRepository)
        {
            _colorRepository = colorRepository;
            _config = config;
            _reponse = new ResponseDto();
            _iPagingRepository = pagingRepository;
        }

        [HttpGet/*, Authorize(Roles = "Admin,User")*/]
        public async Task<IActionResult> GetAllColor()
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
            return Ok(await _colorRepository.GetAllColors());
        }
        [HttpPost("CreateColor")]
        public async Task<IActionResult> CreateColor(ColorEntity obj)
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
            if (await _colorRepository.Create(obj))
            {
                return Ok("Thêm thành công");
            }
            return BadRequest("Thêm thất bại");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateColor(ColorEntity obj)
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
            if (await _colorRepository.Update(obj))
            {
                return Ok("Sửa thành công");
            }
            return BadRequest("Sửa thất bại");
        }
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteColor(Guid id)
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
            if (await _colorRepository.Delete(id))
            {
                return Ok("Xóa thành công");
            }
            return BadRequest("Xóa thất bại");

        }


        [HttpGet("GetColorFSP")]
        public async Task<IActionResult> GetColorFSP(string? search,  decimal? from, decimal? to, string? sortBy, int page)
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
            _reponse.Result = _iPagingRepository.GetAllColor(search, from, to, sortBy, page);
            _reponse.Count = 10;
            return Ok(_reponse);
        }

        [HttpGet("GetColorById")]
        public async Task<IActionResult> GetColorById(int id)
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
            //_reponse.Result = _colorRepository.GetById(guid);
            return Ok(await _colorRepository.GetById(id));
        }

    }
}
