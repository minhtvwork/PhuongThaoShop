using Abp.Application.Services.Dto;
using PTS.Base.Application.Dto;
using PTS.Domain.Dto;
using PTS.Domain.Entities;

namespace PTS.Domain.IRepository
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
