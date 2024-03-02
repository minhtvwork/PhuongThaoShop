using PTS.Domain.Dto;
using PTS.Domain.Entities;

namespace PTS.EntityFrameworkCore.Repository.IRepository
{
    public interface IProductTypeRepository
    {
        Task<bool> Create(ProductTypeEntity obj);
        Task<bool> Update(ProductTypeEntity obj);
        Task<bool> Delete(int id);
        Task<IEnumerable<ProductTypeEntity>> GetAll();
        Task<ProductTypeEntity> GetById(int id);
    }
}
