using PTS.Domain.Dto;
using PTS.Domain.Entities;

namespace PTS.EntityFrameworkCore.Repository.IRepository
{
    public interface ISerialRepository
    {
        Task<ResponseDto> Create(SerialEntity obj);
        Task<bool> CreateMany(List<SerialEntity> listObj);
        Task<ResponseDto> Update(SerialEntity obj);
        Task<bool> Delete(int id);
        Task<IEnumerable<SerialEntity>> GetAll();
    }
}
