using PTS.Domain.Dto;
using PTS.Domain.Entities;

namespace PTS.Domain.IRepository
{
    public interface IGiamGiaRepository
    {
        Task<bool> Create(GiamGiaEntity obj);
        Task<bool> Update(GiamGiaEntity obj);
        Task<bool> Delete(int id);
        Task<List<GiamGiaEntity>> GetAllGiamGias();
        Task<GiamGiaEntity> GetGiamGiaByPromotionType(string promotionType);


    }
}
