﻿using Abp.Application.Services.Dto;
using PTS.Shared.Dto;
using PTS.Core.Dto;
using PTS.Core.Entities;

namespace PTS.Core.Repositories
{
    public interface IManufacturerRepository
    {
        Task<bool> Create(ManufacturerEntity obj);
        Task<bool> Update(ManufacturerEntity obj);
        Task<bool> Delete(int id);
        Task<IEnumerable<ManufacturerEntity>> GetList();
        Task<ManufacturerEntity> GetById(int id);
        Task<PagedResultDto<ManufacturerDto>> GetPagedAsync(PagedRequestDto request);

    }
}