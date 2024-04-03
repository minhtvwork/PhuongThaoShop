using Abp.Application.Services.Dto;
using PTS.Base.Application.Dto;
using PTS.Domain.Dto;
using PTS.Domain.Entities;

namespace PTS.Domain.IRepository
{
    public interface IScreenRepository
    {
        Task<bool> Create(ScreenEntity obj);
        Task<bool> Update(ScreenEntity obj);
        Task<bool> Delete(int id);
        Task<IEnumerable<ScreenEntity>> GetList();
        Task<PagedResultDto<ScreenDto>> GetPagedAsync(PagedRequestDto request);
        Task<ScreenEntity> GetById(int id);
    }
}
