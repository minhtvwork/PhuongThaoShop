using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTS.Domain.Dto;
using PTS.Domain.Entities;
using PTS.Domain.IRepository;

namespace PTS.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SerialController : PTSBaseController
    {
        private readonly ISerialRepository _repository;
        private readonly IConfiguration _config;
        private readonly ResponseDto _reponse;
        private readonly IPagingRepository _iPagingRepository;
        public SerialController(ISerialRepository repository, IConfiguration config, IPagingRepository iPagingRepository)
        {
            _repository = repository;
            _config = config;
            _reponse = new ResponseDto();
            _iPagingRepository = iPagingRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSerials()
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
            return Ok(await _repository.GetAll());
        }
        [HttpPost("CreateSerial")]
        public async Task<IActionResult> CreateSerial(SerialEntity obj)
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
            var result = await _repository.Create(obj);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("CreateMany")]
        public async Task<IActionResult> CreateManySerial(List<SerialEntity> listObj)
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
            if (await _repository.CreateMany(listObj))
            {
                return Ok("Thêm thành công");
            }
            return BadRequest("Thêm thất bại");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSerial(SerialEntity obj)
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
            var result = await  _repository.Update(obj);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteSerial(int id)
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
            if (await _repository.Delete(id))
            {
                return Ok("Xóa thành công");
            }
            return BadRequest("Xóa thất bại");
        }

        [HttpGet("GetSerialPG")]
        public IActionResult GetSerialPG(string? search, decimal? from, decimal? to, string? sortBy, int page)
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
            _reponse.Result = _iPagingRepository.GetAllSerial(search, from, to, sortBy, page);
            var count = _reponse.Count = _iPagingRepository.GetAllSerial(search, from, to, sortBy, page).Count;
            return Ok(_reponse);
        }
    }
}
