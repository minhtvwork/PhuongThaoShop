using MediatR;
using Microsoft.EntityFrameworkCore;
using PTS.Core.Entities;
using PTS.Data;
using PTS.Core.Repositories;
using PTS.Core.Dto;
using PTS.Core.Services;

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
