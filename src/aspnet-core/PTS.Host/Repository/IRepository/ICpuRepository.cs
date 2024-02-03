using PTS.Domain.Dto;
using PTS.Domain.Entities;

namespace PTS.EntityFrameworkCore.Repository.IRepository
{
    public interface ICpuRepository
    {
        Task<bool> Create(CpuEntity obj);
        Task<bool> Update(CpuEntity obj);
        Task<bool> Delete(int id);
        Task<List<CpuEntity>> GetAllCpuEntity();
        Task<CpuEntity> GetById(int id);
    }
}
