using PTS.Domain.Dto;
using PTS.Domain.Entities;

namespace PTS.EntityFrameworkCore.Repository.IRepository
{
    public interface IRamRepository
    {
        Task<bool> Create(RamEntity obj);
        Task<bool> Update(RamEntity obj);
        Task<bool> Delete(int id);
        Task<List<RamEntity>> GetAllRams();
        Task<RamEntity> GetById(int id);
    }
}
