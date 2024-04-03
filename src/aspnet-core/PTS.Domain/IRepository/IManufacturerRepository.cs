using Abp.Application.Services.Dto;
using PTS.Base.Application.Dto;
using PTS.Domain.Dto;
using PTS.Domain.Entities;

namespace PTS.Domain.IRepository
{
    public interface IManufacturerRepository
    {
        Task<bool> Create(ManufacturerEntity obj);
        Task<bool> Update(ManufacturerEntity obj);
        Task<bool> Delete(int id);
        Task<IEnumerable<ManufacturerEntity>> GetList();
        Task<ManufacturerEntity> GetById(int id);
        Task<PagedResultDto<ManufacturerDto>> GetPagedAsync(PagedRequestDto request);

    }
}
