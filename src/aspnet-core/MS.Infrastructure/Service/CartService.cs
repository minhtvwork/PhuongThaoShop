using PTS.EntityFrameworkCore.Repository.IRepository;
using PTS.Host.Service.IService;
using PTS.Domain.Dto;
using PTS.Domain.Entities;

namespace PTS.Host.Service
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICartDetailRepository _cartDetailRepository;
        private readonly IProductDetailRepository _productDetailRepository;
        private readonly IUserRepository _userRepository;
        private readonly ResponseDto _reponse;
        private static int getUserId;  // Tạo 1 biết static phạm vi private dùng trong controller
        /*
          Các trạng thái của cart detail
         1: Trạng thái mặc định khi thêm sản phẩm vào giỏ hàng
         2: Trạng thái chờ của sản phẩm khi thêm vào hóa đơn chi tiết
         0: Trạng thái ẩn sản phẩm trong giỏ hàng
         */
        public CartService(ICartRepository cartRepository, ICartDetailRepository cartDetailRepository,
            IProductDetailRepository productDetailRepository, IUserRepository userRepository)
        {
            _cartRepository = cartRepository;
            _cartDetailRepository = cartDetailRepository;
            _productDetailRepository = productDetailRepository;
            _userRepository = userRepository;
            _reponse = new ResponseDto();
        }
        public async Task<ServiceResponse> AddCart(string username, int idProductDetail)
        {
            try
            {
                var productDetailToCart = _productDetailRepository.GetById(idProductDetail).Result;
                var userToCart = await _userRepository.GetAllUsers();
                var user = userToCart.FirstOrDefault(x => x.Username == username);

                if (user == null)
                {
                   return new ServiceResponse(false, "Không tìm thấy tài khoản");
                }

                if (productDetailToCart == null)
                {
                    return new ServiceResponse(false, "Sản phẩm không tồn tại");
                }

                getUserId = user.Id;
                var userCart = await _cartRepository.GetCartById(getUserId);
                var soLuongProductDetail = 1; // productDetailToCart.AvailableQuantity;

                if (soLuongProductDetail <= 0)
                {
                    return new ServiceResponse(false, "Số lượng sản phẩm không đủ");
                }

                if (userCart != null)
                {
                    var checkProductDetailInCart = await _cartDetailRepository.GetAll();
                    var cartDetail = checkProductDetailInCart.FirstOrDefault(a => a.CartEntityId == getUserId && a.ProductDetailEntityId == productDetailToCart.Id);

                    if (cartDetail != null)
                    {
                        cartDetail.Quantity += 1;

                        if (await _cartDetailRepository.Update(cartDetail))
                        {
                            return new ServiceResponse(true, "Cập nhật thành công");
                        }

                        return new ServiceResponse(false, "Cập nhật thất bại");
                    }
                    else
                    {
                        var newCartDetail = new CartDetailEntity
                        {
                            Id = 0,
                            ProductDetailEntityId = productDetailToCart.Id,
                            CartEntityId = getUserId,
                            Quantity = 1,
                            Status = 1
                        };

                        if (await _cartDetailRepository.Create(newCartDetail))
                        {
                            return new ServiceResponse(true, "Thêm sản phẩm vào giỏ hàng thành công");
                        }

                        return new ServiceResponse(false, "Không thể thêm sản phẩm vào trong giỏ hàng");
                    }
                }
                else
                {
                    var newCart = new CartEntity
                    {
                        UserEntityId = getUserId,
                        Description = $"Giỏ hàng của {username}"
                    };

                    if (await _cartRepository.Create(newCart))
                    {
                        var newCartDetail = new CartDetailEntity
                        {
                            Id = 0,
                            ProductDetailEntityId = productDetailToCart.Id,
                            CartEntityId = getUserId,
                            Quantity = 1,
                            Status = 1
                        };

                        if (await _cartDetailRepository.Create(newCartDetail))
                        {
                            return new ServiceResponse(true, "Thêm sản phẩm vào giỏ hàng thành công");
                        }
                    }

                    return new ServiceResponse(false, "Thêm sản phẩm vào giỏ hàng thất bại");
                }
            }
            catch (Exception e)
            {
            return new ServiceResponse(false, $"{e.Message}");
            }
        }

        private ResponseDto ErrorResponse(string message, int code)
        {
            return new ResponseDto
            {
                Result = null,
                IsSuccess = false,
                Code = code,
                Message = message
            };
        }

        private ResponseDto SuccessResponse(object result, int code, string message = null)
        {
            return new ResponseDto
            {
                Result = result,
                IsSuccess = true,
                Code = code,
                Message = message
            };
        }
        public async Task<ResponseDto> CongOrTruQuantityCartDetail(int idCartDetail, int changeAmount)
        {
            try
            {
                var cartDetailX = await _cartDetailRepository.GetById(idCartDetail);

                if (cartDetailX == null)
                {
                    return ErrorResponse("Không tìm thấy giỏ hàng chi tiết", 404);
                }

                var checkProductDetailInCart = cartDetailX.Quantity;
                CartDetailEntity cartDetail = new CartDetailEntity
                {
                    Id = idCartDetail,
                    Quantity = checkProductDetailInCart + changeAmount
                };

                if (cartDetail.Quantity < 0)
                {
                    return await HandleNegativeQuantity(cartDetail);
                }

                if (await _cartDetailRepository.Update(cartDetail))
                {
                    return SuccessResponse(cartDetail, 200, $"{(changeAmount > 0 ? "Tăng" : "Giảm")} số lượng sản phẩm thành công");
                }
                else
                {
                    return ErrorResponse("Thất bại", 404);
                }
            }
            catch (Exception e)
            {
                return ErrorResponse(e.Message, 404);
            }
        }

        private async Task<ResponseDto> HandleNegativeQuantity(CartDetailEntity cartDetail)
        {
            if (await _cartDetailRepository.Delete(cartDetail.Id))
            {
                return SuccessResponse(null, 204, "Bạn vừa xóa sản phẩm khỏi giỏ hàng");
            }

            return ErrorResponse("Thất bại, có lỗi gì đó", 404);
        }

        public async Task<ResponseDto> CongQuantityCartDetail(int idCartDetail)
        {
            return await CongOrTruQuantityCartDetail(idCartDetail, 1);
        }

        public async Task<ResponseDto> TruQuantityCartDetail(int idCartDetail)
        {
            return await CongOrTruQuantityCartDetail(idCartDetail, -1);
        }

        public async Task<ResponseDto> GetListCarts()
        {
            var cartItem = await _cartRepository.GetAll();
            if (cartItem == null)
            {
                _reponse.Result = null;
                _reponse.IsSuccess = false;
                _reponse.Code = 404;
                _reponse.Message = "Lỗi";
                return _reponse;
            }
            else
            {
                _reponse.Result = cartItem;
                _reponse.Code = 200;
                return _reponse;
            }

        }
        public async Task<ResponseDto> GetCartById(int id)
        {
            var cartItem = await _cartRepository.GetCartById(id);
            if (cartItem == null)
            {
                _reponse.Result = null;
                _reponse.IsSuccess = false;
                _reponse.Code = 404;
                _reponse.Message = "Lỗi";
                return _reponse;
            }
            else
            {
                _reponse.Result = cartItem;
                _reponse.Code = 200;
                return _reponse;
            }

        }
        public async Task<ResponseDto> GetCartByUser(string username)
        {
            var cartItem = await _cartRepository.GetCartItem(username);
            if (cartItem == null)
            {
                _reponse.Result = null;
                _reponse.IsSuccess = false;
                _reponse.Code = 404;
                _reponse.Message = "Lỗi";
                return _reponse;
            }
            else
            {
                _reponse.Result = cartItem;
                _reponse.Count = cartItem.Count();
                _reponse.Code = 200;
                return _reponse;
            }

        }
    }
}
