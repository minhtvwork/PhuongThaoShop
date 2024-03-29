using PTS.Domain.Dto;
using PTS.Domain.Entities;

namespace PTS.EntityFrameworkCore.Repository.IRepository
{
    public interface IContactRepository
    {
        Task<ServiceResponse> Create( ContactEntity obj );
        Task<ServiceResponse> Update(ContactEntity obj);
        Task<ServiceResponse> Delete(int id);
        Task<IEnumerable<ContactEntity>> GetList();
    }
}
