using Abp.Application.Services.Dto;
using PTS.Base.Application.Dto;
using PTS.Domain.Dto;
using PTS.Domain.Entities;

namespace PTS.Domain.IRepository
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
