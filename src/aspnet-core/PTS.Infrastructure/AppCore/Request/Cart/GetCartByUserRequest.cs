using MediatR;
using Microsoft.EntityFrameworkCore;
using PTS.Domain.Entities;
using PTS.Data;
using PTS.EntityFrameworkCore.Repository.IRepository;
using PTS.Domain.Dto;
using PTS.Host.Service.IService;

namespace PTS.Host.AppCore.Request
{
    public class GetCartByUserQuery : IRequest<ResponseDto>
    {
       public string? Username { get; set; }
    }
    public class GetCartByUserHandler : IRequestHandler<GetCartByUserQuery, ResponseDto>
    {
        private readonly ICartService _cartService;
        public GetCartByUserHandler(ICartService  cartService)
        {
          _cartService = cartService;
        }
        public async Task<ResponseDto> Handle(GetCartByUserQuery request, CancellationToken cancellationToken)
        {
            return await _cartService.GetCartByUser(request.Username);
        }
    }
}
