using PTS.Domain.Dto;

namespace PTS.Host.Service.IService
{
    public interface IGiamGiaHangLoatServices
    {
        Task<ResponseDto> ApplyDiscountByPromotionType(string promotionType, double discountAmount);
    }
}
