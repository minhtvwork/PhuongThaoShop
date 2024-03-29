﻿using MediatR;
using PTS.Domain.Dto;
using PTS.Domain.Entities;
using PTS.EntityFrameworkCore.Repository.IRepository;
using PTS.Host.Service.IService;

namespace PTS.Host.AppCore.Request.Cart
{
    public class UpdateQuantityCartItemQuery : IRequest<ServiceResponse>
    {
        public int Quantity { get; set; }
        public int IdCartDetail { get; set; }
    }
    public class UpdateQuantityCartItemHandler : IRequestHandler<UpdateQuantityCartItemQuery, ServiceResponse>
    {
        private readonly ICartDetailRepository _repo;
        public UpdateQuantityCartItemHandler(ICartDetailRepository repo)
        {
            _repo = repo;
        }
        public async Task<ServiceResponse> Handle(UpdateQuantityCartItemQuery request, CancellationToken cancellationToken)
        {
            CartDetailEntity cartDetail = new CartDetailEntity();
            cartDetail.Id = request.IdCartDetail;
            cartDetail.Quantity = request.Quantity;
            if (await _repo.UpdateQuantity(cartDetail))
            {
                return new ServiceResponse(true, "Cập nhật hành công");
            }
            return new ServiceResponse(false, "Cập nhật thất bại");
        }
    }
}
