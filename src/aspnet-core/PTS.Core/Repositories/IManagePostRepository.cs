﻿using Abp.Application.Services.Dto;
using PTS.Shared.Dto;
using PTS.Core.Dto;
using PTS.Core.Entities;

namespace PTS.Core.Repositories
{
    public interface IManagePostRepository
    {
        Task<bool> Create(ManagePostEntity obj);
        Task<bool> Update(ManagePostEntity obj);
        Task<bool> Delete(int id);
        Task<IEnumerable<ManagePostEntity>> GetList();
        Task<PagedResultDto<ManagePostDto>> GetPagedAsync(PagedRequestDto request);
        Task<ManagePostEntity> GetById(int id);
    }
}