using PTS.Domain.Dto;
using PTS.Domain.Entities;

namespace PTS.Domain.IRepository
{
    public interface ISanPhamGiamGiaRepository
    {
        Task<ResponseDto> Create(SanPhamGiamGiaEntity obj);
        Task<bool> Update(SanPhamGiamGiaEntity obj);
        Task<bool> Delete(int id);
        Task<List<SanPhamGiamGiaEntity>> GetAllSanPhamGiamGias();
        Task<SanPhamGiamGiaEntity> GetById(int id);

    }
}
