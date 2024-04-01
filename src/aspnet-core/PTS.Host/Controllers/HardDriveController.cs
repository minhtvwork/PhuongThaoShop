using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTS.Domain.Dto;
using PTS.Domain.Entities;
using PTS.Domain.IRepository;
using PTS.Host.Controllers;
using PTS.Domain.IRepository;
using System.Linq.Expressions;

namespace Shop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HardDriveController : PTSBaseController
    {
        private readonly IAllRepository<HardDriveEntity> _repository;
        private readonly IMapper _mapper;
        public HardDriveController(IAllRepository<HardDriveEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet("GetAllAsync")]
        public async Task<ActionResult<IEnumerable<HardDriveDto>>> GetAllAsync()
        {
            var listObj = await _repository.GetAllAsync();
            return Ok(listObj.Where(x => !x.IsDeleted));
        }
        [HttpGet("GetByIdAsync")]
        public async Task<ActionResult<HardDriveDto>> GetByIdAsync(int id)
        {
            var obj = await _repository.GetByIdAsync(id);
            return Ok(obj);
        }
        [AllowAnonymous]
        [HttpPost("GetPagesAsync")]
        public async Task<ActionResult<IEnumerable<HardDriveEntity>>> GetPagesAsync(int page, int pageSize)
        {
            Expression<Func<HardDriveEntity, bool>> predicate = x => x.IsDeleted == false;
            var result = await _repository.GetPagedAsync(page, pageSize, predicate);
            return Ok(result);
        }
        [HttpPost("CreateOrUpdateAsync")]
        public async Task<ActionResult> CreateOrUpdateAsync(HardDriveDto objDto)
        {
            var obj = _mapper.Map<HardDriveEntity>(objDto);
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
        [AllowAnonymous]
        [HttpPost("DeleteAsync")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var obj = await _repository.GetByIdAsync(id);
            obj.IsDeleted = true;
            if (await _repository.UpdateAsync(obj))
                return Ok(obj);
            return BadRequest();
        }
    }
}
