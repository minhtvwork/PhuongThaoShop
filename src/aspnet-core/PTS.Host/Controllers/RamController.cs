﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTS.Shared.Dto;
using PTS.Core.Dto;
using PTS.Core.Entities;
using PTS.Core.Repositories;
using PTS.Host.Controllers;
using PTS.Host.Model.Base;

namespace Shop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RamController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public RamController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            return Ok(await _unitOfWork._ramRepository.GetList());
        }
        [HttpPost("GetPaged")]
        public async Task<IActionResult> GetPaged(PagedRequestDto request)
        {
            return Ok(await _unitOfWork._ramRepository.GetPagedAsync(request));
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _unitOfWork._ramRepository.GetById(id));
        }
        [HttpPost("CreateOrUpdateAsync")]
        public async Task<IActionResult> CreateOrUpdateAsync(RamDto objDto)
        {
            var obj = _mapper.Map<RamEntity>(objDto);
            bool isSuccess;

            if (objDto.Id > 0)
            {
                isSuccess = await _unitOfWork._ramRepository.Update(obj);
            }
            else
            {
                isSuccess = await _unitOfWork._ramRepository.Create(obj);
            }

            if (isSuccess)
            {
                return Ok(new ApiSuccessResult<RamEntity>(obj));
            }
            else
            {
                return Ok(new ApiErrorResult<RamEntity>("Error"));
            }
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if(await _unitOfWork._ramRepository.Delete(id))
            {
                return Ok(new ApiSuccessResult<RamEntity>());
            }
            else
            {
                return Ok(new ApiErrorResult<RamEntity>("Error"));
            }
        }
    }
}
