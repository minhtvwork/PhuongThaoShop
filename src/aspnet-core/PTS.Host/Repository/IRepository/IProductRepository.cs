using PTS.Domain.Dto;
using PTS.Domain.Entities;
namespace PTS.EntityFrameworkCore.Repository.IRepository
{
    public interface IProductRepository
    {
        Task<bool> Create(ProductEntity obj);
        Task<bool> Update(ProductEntity obj);
        Task<bool> Delete(int idobj);

        Task<IEnumerable<ProductEntity>> GetAll();
        Task<ProductEntity> GetById(int id);
        Task<IEnumerable<ProductDto>> GetProductDtos(string? search, decimal? from, decimal? to, string? sortBy, int page = 1);
    }
}
