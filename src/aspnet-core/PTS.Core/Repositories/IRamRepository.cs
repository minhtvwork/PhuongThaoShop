﻿using Abp.Application.Services.Dto;
using PTS.Shared.Dto;
using PTS.Core.Dto;
using PTS.Core.Entities;

namespace PTS.Core.Repositories
{
    public interface IRamRepository
    {
        Task<bool> Create(RamEntity obj);
        Task<bool> Update(RamEntity obj);
        Task<bool> Delete(int id);
        Task<IEnumerable<RamEntity>> GetList();
        Task<PagedResultDto<RamDto>> GetPagedAsync(PagedRequestDto request);
        Task<RamEntity> GetById(int id);
    }
}