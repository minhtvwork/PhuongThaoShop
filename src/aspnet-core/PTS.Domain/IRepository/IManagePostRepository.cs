using PTS.Domain.Dto;
using PTS.Domain.Entities;

namespace PTS.Domain.IRepository
{
    public interface IManagePostRepository
    {
        Task<bool> Create(ManagePostEntity managePost);
        Task<bool> Update(ManagePostEntity managePost);
        Task<bool> Delete(int Id);
        Task<ResponseDto> Duyet(int Id);
        Task<ResponseDto> HuyDuyet(int Id);
        Task<ManagePostEntity> GetById(int Id);
        Task<bool> GetByCode(int Id);
        Task<List<ManagePostEntity>> GetAllManagePosts();
        Task<IEnumerable<ManagePostEntity>> GetManagePostDtos(string? search, DateTime? from, DateTime? to, string? sortBy, bool? status, int page = 1);
    }
}
