using PTS.Application.Dto;

namespace PTS.Core.Services
{
    public interface ICartService
    {
        Task<ServiceResponse> AddCart(string username, int  idProductDetail);// Phương thức để người dùng tạo giỏ hàng
        Task<ResponseDto> GetListCarts();// Cho admin quản lý
        Task<ResponseDto> GetCartById(int id);// Cho admin quản lý
        Task<ResponseDto> GetCartByUser(string username);// Hiển thị giỏ hàng cho người dùng
    }
}
