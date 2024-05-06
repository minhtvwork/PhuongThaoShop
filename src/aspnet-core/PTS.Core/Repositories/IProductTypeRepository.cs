﻿using Abp.Application.Services.Dto;
using PTS.Shared.Dto;
using PTS.Core.Dto;
using PTS.Core.Entities;

namespace PTS.Core.Repositories
{
    public interface IProductTypeRepository
    {
        Task<bool> Create(ProductTypeEntity obj);
        Task<bool> Update(ProductTypeEntity obj);
        Task<bool> Delete(int id);
        Task<IEnumerable<ProductTypeEntity>> GetList();
        Task<PagedResultDto<ProductTypeDto>> GetPagedAsync(PagedRequestDto request);
        Task<ProductTypeEntity> GetById(int id);
    }
}
