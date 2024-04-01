using PTS.Domain.Dto;

namespace PTS.Domain.IService
{
    public interface IGiamGiaHangLoatServices
    {
        Task<ResponseDto> ApplyDiscountByPromotionType(string promotionType, double discountAmount);
    }
}
