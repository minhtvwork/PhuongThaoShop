using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTS.Domain.Entities;
using PTS.EntityFrameworkCore.Repository.IRepository;
using PTS.Host.Controllers;

namespace Shop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RamController : PTSBaseController
    {
        private readonly IRamRepository _repository;
        private readonly IConfiguration _config;
        private readonly IPagingRepository _iPagingRepository;
       // private readonly ResponseDto _reponse;


        public RamController(IRamRepository repository, IConfiguration config)
        {
            _repository = repository;
            _config = config;
          //  _reponse = new ResponseDto();

        }
        [HttpGet]
        public async Task<IActionResult> GetAllRam()
        {
            return Ok(await _repository.GetAllRams());
        }
        [HttpPost("CreateRam")]
        public async Task<IActionResult> CreateRam(RamEntity obj)
        {
            if (await _repository.Create(obj))
            {
                return Ok("Thêm thành công");
            }
            return BadRequest("Thêm thất bại");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateRam(RamEntity obj)
        {

            if (await _repository.Update(obj))
            {
                return Ok("Sửa thành công");
            }
            return BadRequest("Sửa thất bại");
        }
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteRam(int id)
        {
            if (await _repository.Delete(id))
            {
                return Ok("Xóa thành công");
            }
            return BadRequest("Xóa thất bại");

        }

    }
}
