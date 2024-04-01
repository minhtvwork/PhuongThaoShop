using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTS.Domain.Dto;
using PTS.Domain.Entities;
using PTS.Domain.IRepository;

namespace PTS.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : PTSBaseController
    {
        private readonly IColorRepository _repo;
        private readonly IMapper _mapper;
        private readonly ResponseDto _reponse;
        private readonly IUnitOfWork _unitOfWork;
        public ColorController(IColorRepository repo, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repo = repo;
            _mapper = mapper;
            _reponse = new ResponseDto();
            _unitOfWork = unitOfWork;

        }
        [AllowAnonymous]
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
          var x=  _unitOfWork._colorRepository.GetList();
          return Ok(x);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _repo.GetById(id));
        }
        [HttpPost("CreateOrUpdateAsync")]
        public async Task<IActionResult> CreateOrUpdateAsync(ColorDto objDto)
        {
            var obj = _mapper.Map<ColorEntity>(objDto);
            if(objDto.Id > 0)
            {  
              return Ok(await _repo.Update(obj));
            }
            else
            {
                return Ok(await _repo.Create(obj));
            }
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
         return Ok(await _repo.Delete(id));
        }
    }
}
