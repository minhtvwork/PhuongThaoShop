﻿using Abp.Application.Services.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PTS.Domain.Dto;
using PTS.Domain.Entities;
using PTS.Domain.IRepository;
using System.Linq.Expressions;

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
        [HttpPost("GetPagesAsync")]
        public async Task<ActionResult<IEnumerable<CpuEntity>>> GetPagesAsync(int page, int pageSize)
        {
            Expression<Func<CpuEntity, bool>> predicate = x => x.IsDeleted == false;
            var result = await _repository.GetPagedAsync(page, pageSize, predicate);
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
