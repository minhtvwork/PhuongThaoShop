using PTS.Domain.Dto;

namespace PTS.Host.Service.IService
{
    public interface ICartService
    {
        Task<ResponseDto> AddCart(string username, string codeProductDetail);// Phương thức để người dùng tạo giỏ hàng
        Task<ResponseDto> CongQuantityCartDetail(int idCartDetail);
        Task<ResponseDto> TruQuantityCartDetail(int idCartDetail);
        Task<ResponseDto> GetListCarts();// Cho admin quản lý
        Task<ResponseDto> GetCartById(int id);// Cho admin quản lý
        Task<ResponseDto> PShowCart(string username);// Hiển thị giỏ hàng cho người dùng
    }
}
