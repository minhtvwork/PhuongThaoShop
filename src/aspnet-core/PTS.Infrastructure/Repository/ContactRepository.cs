using Microsoft.EntityFrameworkCore;

using PTS.EntityFrameworkCore.Repository.IRepository;
using PTS.Domain.Entities;
using PTS.Data;
using PTS.Domain.Dto;

namespace PTS.EntityFrameworkCore.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ContactRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        public async Task<ServiceResponse> Create(ContactEntity contact)
        {
            if (contact == null)
            {
                return new ServiceResponse(false, "Thêm thất bại");
            }
            try
            {
                await _dbContext.ContactEntity.AddAsync(contact);
                await _dbContext.SaveChangesAsync();
                return new ServiceResponse(true, "Thêm thành công");
            }
            catch (Exception)
            {
                return new ServiceResponse(false, "Thêm thất bại");
            }
        }

        public async Task<ServiceResponse> Delete(int Id)
        {
            var obj = await _dbContext.ContactEntity.FindAsync(Id);
            if (obj == null)
            {
                return new ServiceResponse(false, "Xóa thất bại");
            }
            try
            {
                obj.IsDeleted = true;
                _dbContext.ContactEntity.Update(obj);
                await _dbContext.SaveChangesAsync();
                return new ServiceResponse(true, "Xóa thành công");
            }
            catch (Exception)
            {
                return new ServiceResponse(false, "Xóa thất bại");
            }
        }

        public async Task<IEnumerable<ContactEntity>> GetList()
        {
            return await _dbContext.ContactEntity.Where(a=>!a.IsDeleted).ToListAsync();
        }

        public async Task<ServiceResponse> Update(ContactEntity contact)
        {
            var obj = await _dbContext.ContactEntity.FindAsync(contact.Id);
            if (obj == null)
            {
                return new ServiceResponse(false, "Cập nhật thất bại");
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
                return new ServiceResponse(true, "Cập nhật thành công");
            }
            catch (Exception)
            {
                return new ServiceResponse(false, "Cập nhật thất bại");
            }
        }
    }
}
