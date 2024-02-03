using PTS.Domain.Dto;
using PTS.Domain.Entities;

namespace PTS.EntityFrameworkCore.Repository.IRepository
{
    public interface IColorRepository
    {
        Task<bool> Create(ColorEntity obj);
        Task<bool> Update(ColorEntity obj);
        Task<bool> Delete(int id);
        Task<List<ColorEntity>> GetAllColors();
        Task<ColorEntity> GetById(int id);
    }
}
