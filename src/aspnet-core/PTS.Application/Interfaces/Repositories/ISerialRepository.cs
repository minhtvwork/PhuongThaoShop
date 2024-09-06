using PTS.Domain.Entities;

namespace PTS.Application.Interfaces.Repositories
{
    public interface ISerialRepository
    {
        Task<bool> Create(SerialEntity obj);
        Task<bool> CreateMany(List<SerialEntity> listObj);
        Task<bool> Update(SerialEntity obj);
        Task<bool> Delete(int id);
        Task<IEnumerable<SerialEntity>> GetList();
        Task<SerialEntity> GetById(int id);
        Task<SerialEntity> FindBySerialNumberAsync(string serialNumber);
    }
}
