
using PTS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using PTS.EntityFrameworkCore.Repository.IRepository;
using PTS.Data;

namespace PTS.EntityFrameworkCore.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public RoleRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Create(RoleEntity obj)
        {
        var checkRoleName = await _dbContext.RoleEntity.AnyAsync(x => x.RoleName == obj.RoleName);

            if (obj == null || checkRoleName == true)
            {
                return false;
            }
            try
            {
                await _dbContext.RoleEntity.AddAsync(obj);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var role = await _dbContext.RoleEntity.FindAsync(id);
            if (role == null)
            {
                return false;
            }
            try
            {
                role.Status = 0;
                _dbContext.RoleEntity.Update(role);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<RoleEntity>> GetAllRoles()
        {
            var list = await _dbContext.RoleEntity.ToListAsync();// lấy tất cả role
            var listRoles = list.Where(x => x.Status != 0).ToList();// lấy tất cả role với điều kiện trạng thái khác 0
            return listRoles;
        }

        public async Task<RoleEntity> GetById(int id)
        {
            var respone = await _dbContext.RoleEntity.FirstOrDefaultAsync(x => x.Id == id);
            if (respone==null)
                throw new ArgumentException(IRoleRepository.Role_NoteFound);
            return respone;
        }

        public async Task<bool> Update(RoleEntity obj)
        {
            var role = await _dbContext.RoleEntity.FindAsync(obj.Id);
            if (role == null)
            {
                return false;
            }
            try
            {
                role.RoleName = obj.RoleName;
                role.Status = obj.Status;
                _dbContext.RoleEntity.Update(role);
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
