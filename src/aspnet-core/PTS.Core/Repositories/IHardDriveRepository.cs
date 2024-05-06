using Abp.Application.Services.Dto;
using PTS.Shared.Dto;
using PTS.Core.Dto;
using PTS.Core.Entities;

namespace PTS.Core.Repositories
{
    public interface IHardDriveRepository
    {
        Task<bool> Create(HardDriveEntity obj);
        Task<bool> Update(HardDriveEntity obj);
        Task<bool> Delete(int id);
        Task<IEnumerable<HardDriveEntity>> GetList();
        Task<PagedResultDto<HardDriveDto>> GetPagedAsync(PagedRequestDto request);
        Task<HardDriveEntity> GetById(int id);

    }
}
