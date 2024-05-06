using Abp.Application.Services.Dto;
using PTS.Shared.Dto;
using PTS.Core.Dto;
using PTS.Core.Entities;

namespace PTS.Core.Repositories
{
    public interface ISerialRepository
    {
        Task<bool> Create(SerialEntity obj);
        Task<bool> CreateMany(List<SerialEntity> listObj);
        Task<bool> Update(SerialEntity obj);
        Task<bool> Delete(int id);
        Task<PagedResultDto<SerialDto>> GetPagedAsync(PagedRequestDto request);
        Task<IEnumerable<SerialEntity>> GetList();
        Task<SerialEntity> GetById(int id);
    }
}
