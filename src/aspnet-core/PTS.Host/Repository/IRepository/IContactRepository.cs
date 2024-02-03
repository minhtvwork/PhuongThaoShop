using PTS.Domain.Entities;

namespace PTS.EntityFrameworkCore.Repository.IRepository
{
    public interface IContactRepository
    {
        Task<bool> Create( ContactEntity contact );
        Task<bool> Update(ContactEntity contact);
        Task<bool> Delete(int Id);
        Task<List<ContactEntity>> GetAllContacts();
    }
}
