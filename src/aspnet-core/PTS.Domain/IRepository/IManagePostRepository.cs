using Abp.Application.Services.Dto;
using PTS.Base.Application.Dto;
using PTS.Domain.Dto;
using PTS.Domain.Entities;

namespace PTS.Domain.IRepository
{
    public interface IManagePostRepository
    {
        Task<bool> Create(ManagePostEntity obj);
        Task<bool> Update(ManagePostEntity obj);
        Task<bool> Delete(int id);
        Task<IEnumerable<ManagePostEntity>> GetList();
        Task<PagedResultDto<ManagePostDto>> GetPagedAsync(PagedRequestDto request);
        Task<ManagePostEntity> GetById(int id);
    }
}
