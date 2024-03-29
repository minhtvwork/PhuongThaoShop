using PTS.Domain.Dto;
using PTS.Domain.Entities;
namespace PTS.EntityFrameworkCore.Repository.IRepository
{
    public interface IProductDetailRepository
    {
        Task<bool> Create(ProductDetailEntity obj);
        Task<bool> CreateMany(List<ProductDetailEntity> list);
        Task<bool> Update(ProductDetailEntity obj);
        Task<bool> Delete(int id);
        Task<List<ProductDetailEntity>> GetAll();
        Task<IEnumerable<ProductDetailDto>> PGetProductDetail(int? getNumber, string? codeProductDetail, int? status, string? search, decimal? from, decimal? to, string? sortBy, int? page,
            string? productType, string? namufacturer, string? ram, string? CPU, string? cardVGA);
        Task<IEnumerable<ProductDetailDto>> PGetList(PGetListDto request);
        Task<bool> UpdateSoLuong(int id, int soLuong);
        Task<ProductDetailDto> GetById(int id);
    }
}
