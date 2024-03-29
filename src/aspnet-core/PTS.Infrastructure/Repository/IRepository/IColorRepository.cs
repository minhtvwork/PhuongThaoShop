using PTS.Domain.Dto;
using PTS.Domain.Entities;

namespace PTS.EntityFrameworkCore.Repository.IRepository
{
    public interface IColorRepository
    {
        Task<ServiceResponse> Create(ColorEntity obj);
        Task<ServiceResponse> Update(ColorEntity obj);
        Task<ServiceResponse> Delete(int id);
        Task<IEnumerable<ColorEntity>> GetList();
        Task<ColorEntity> GetById(int id);
    }
}
