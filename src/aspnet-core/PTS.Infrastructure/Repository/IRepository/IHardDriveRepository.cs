using PTS.Domain.Dto;
using PTS.Domain.Entities;

namespace PTS.EntityFrameworkCore.Repository.IRepository
{
    public interface IHardDriveRepository
    {
        Task<bool> Create(HardDriveEntity obj);
        Task<bool> Update(HardDriveEntity obj);
        Task<bool> Delete(int id);
        Task<List<HardDriveEntity>> GetAllHardDrives();
        Task<HardDriveEntity> GetById(int id);
    }
}
