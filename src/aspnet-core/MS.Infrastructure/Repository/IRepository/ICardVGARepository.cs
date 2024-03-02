using PTS.Domain.Dto;
using PTS.Domain.Entities;

namespace PTS.EntityFrameworkCore.Repository.IRepository
{
    public interface ICardVGARepository
    {
        Task<bool> Create(CardVGAEntity obj);
        Task<bool> Update(CardVGAEntity obj);
        Task<bool> Delete(int id);
        Task<List<CardVGAEntity>> GetAllCardVGA();
        Task<CardVGAEntity> GetById(int id);
    }
}
