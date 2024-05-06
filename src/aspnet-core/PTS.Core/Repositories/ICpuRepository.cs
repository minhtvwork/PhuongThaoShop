using Abp.Application.Services.Dto;
using PTS.Shared.Dto;
using PTS.Core.Dto;
using PTS.Core.Entities;

namespace PTS.Core.Repositories
{
    public interface ICpuRepository
    {
        Task<bool> Create(CpuEntity obj);
        Task<bool> Update(CpuEntity obj);
        Task<bool> Delete(int id);
        Task<IEnumerable<CpuEntity>> GetList();
        Task<PagedResultDto<CpuDto>> GetPagedAsync(PagedRequestDto request);
        Task<CpuEntity> GetById(int id);
    }
}
