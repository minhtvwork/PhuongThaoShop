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
    public class ContactController : PTSBaseController
    {
        private readonly IContactRepository _repo;
        private readonly IMapper _mapper;
        private readonly ResponseDto _reponse;
        public ContactController(IContactRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
            _reponse = new ResponseDto();
        }
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            return Ok(await _repo.GetList());
        }
        [HttpPost("CreateOrUpdateAsync")]
        public async Task<IActionResult> CreateOrUpdateAsync(ContactDto objDto)
        {
            var obj = _mapper.Map<ContactEntity>(objDto);
            if (objDto.Id > 0)
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
