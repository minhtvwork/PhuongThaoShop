using Abp.Application.Services.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PTS.Domain.Dto;
using PTS.Domain.Entities;
using PTS.Host.Repository.IRepository;

namespace PTS.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CpuController : PTSBaseController
    {
        private readonly IAllRepository<CpuEntity> _repository;
        private readonly IMapper _mapper;
        public CpuController(IAllRepository<CpuEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("GetAllAsync")]
        public async Task<ActionResult<IEnumerable<CpuDto>>> GetAllAsync()
        {
            var listObj = await _repository.GetAllAsync();
            return Ok(listObj.Where(x=>!x.IsDeleted));
        }
        [HttpGet("GetByIdAsync")]
        public async Task<ActionResult<CpuDto>> GetByIdAsync(int id)
        {
            var obj = await _repository.GetByIdAsync(id);
            return Ok(obj);
        }
        [AllowAnonymous]
        [HttpPost("GetPagesAsync")]
        public async Task<ActionResult<IEnumerable<CpuEntity>>> GetPagesAsync(int page, int pageSize)
        {
            var result = await _repository.GetPagedAsync(page, pageSize);
            return Ok(result);
        }
        [HttpPost("CreateOrUpdateAsync")]
        public async Task<ActionResult> CreateOrUpdateAsync(CpuDto objDto)
        {
            var obj = _mapper.Map<CpuEntity>(objDto);
            if (obj.Id > 0)
            {
                if (await _repository.UpdateAsync(obj))
                    return Ok(obj);
                return BadRequest();
            }
            else
            {
                if (await _repository.CreateAsync(obj))
                    return Ok(obj);
                return BadRequest();
            }
          
        }
    }
}
