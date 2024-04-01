using PTS.Domain.Entities;

namespace PTS.Domain.IRepository
{
    public interface IScreenRepository
    {
        Task<bool> Create(ScreenEntity obj);
        Task<bool> Update(ScreenEntity obj);
        Task<bool> Delete(int id);
        Task<IEnumerable<ScreenEntity>> GetAll();
        Task<ScreenEntity> GetById(int id);
    }
}
