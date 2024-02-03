using Microsoft.EntityFrameworkCore;

using PTS.EntityFrameworkCore.Repository.IRepository;
using PTS.Domain.Entities;

namespace PTS.EntityFrameworkCore.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ContactRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        public async Task<bool> Create(ContactEntity contact)
        {
            if (contact == null)
            {
                return false;
            }
            try
            {
                await _dbContext.ContactEntity.AddAsync(contact);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int Id)
        {
            var obj = await _dbContext.ContactEntity.FindAsync(Id);
            if (obj == null)
            {
                return false;
            }
            try
            {
                obj.Status = 0;
                _dbContext.ContactEntity.Update(obj);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<ContactEntity>> GetAllContacts()
        {
            var list = await _dbContext.ContactEntity.ToListAsync();
            var listContact = list.Where(x => x.Status != 0).ToList();
            return listContact;
        }

        public async Task<bool> Update(ContactEntity contact)
        {
            var obj = await _dbContext.ContactEntity.FindAsync(contact.Id);
            if (obj == null)
            {
                return false;
            }
            try
            {
                obj.Email = contact.Email;
                obj.Name = contact.Name;
                obj.Message = contact.Message;
                obj.CreationTime = contact.CreationTime;
                obj.CodeManagePost = contact.CodeManagePost;
                obj.Status = contact.Status;
                obj.Website = contact.Website;
                _dbContext.ContactEntity.Update(obj);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
