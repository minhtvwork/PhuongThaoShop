using Abp.Application.Services.Dto;
using PTS.Base.Application.Dto;
using PTS.Domain.Dto;
using PTS.Domain.Entities;
using System.Threading.Tasks;

namespace PTS.Domain.IRepository
{
    public interface IColorRepository
    {
        Task<ServiceResponse> Create(ColorEntity obj);
        Task<ServiceResponse> Update(ColorEntity obj);
        Task<ServiceResponse> Delete(int id);
        Task<IEnumerable<ColorEntity>> GetList();
        Task<PagedResultDto<ColorDto>> GetPagedAsync(PagedRequestDto request);
        Task<ColorEntity> GetById(int id);
    }
}
