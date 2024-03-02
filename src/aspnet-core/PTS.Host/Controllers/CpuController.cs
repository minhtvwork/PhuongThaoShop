using AutoMapper;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CpuDto>>> GetAllAsync()
        {
            var products = await _repository.GetAllAsync();
            return Ok(products);
        }
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<CpuDto>>> GetPagesAsync(int page = 1, int pageSize = 10)
        //{
        //    var products = await _repository.GetPagedAsync(page, pageSize).Result.Where(x => !x.IsDeleted).ToList();
        //    return Ok(products);
        //}
        [HttpPost]
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
