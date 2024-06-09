﻿using PTS.Domain.Entities;

namespace PTS.Application.Interfaces.Repositories
{
    public interface ICartDetailRepository
    {
        Task<bool> Create(CartDetailEntity obj);
        Task<bool> UpdateQuantity(CartDetailEntity obj);
        Task<bool> Delete(int id);
        Task<CartDetailEntity> GetById(int id);
        Task<IEnumerable<CartDetailEntity>> GetAll();

    }
}
