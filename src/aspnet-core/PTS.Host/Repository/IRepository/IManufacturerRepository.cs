using PTS.Domain.Dto;
using PTS.Domain.Entities;

namespace PTS.EntityFrameworkCore.Repository.IRepository
{
    public interface IManufacturerRepository
    {
        Task<ResponseDto> Create(ManufacturerEntity obj);
        Task<bool> Update(ManufacturerEntity obj);
        Task<bool> Delete(int idobj);
        Task<IEnumerable<ManufacturerEntity>> GetAll();
        Task<ManufacturerEntity> GetById(int id);

    }
}
