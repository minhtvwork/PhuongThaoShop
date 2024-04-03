using Abp.Application.Services.Dto;
using PTS.Base.Application.Dto;
using PTS.Domain.Dto;
using PTS.Domain.Entities;

namespace PTS.Domain.IRepository
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
