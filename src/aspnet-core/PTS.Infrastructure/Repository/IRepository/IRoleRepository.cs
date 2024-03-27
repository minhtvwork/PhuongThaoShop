using PTS.Domain.Entities;

namespace PTS.EntityFrameworkCore.Repository.IRepository
{
    public interface IRoleRepository
    {
        public const string Role_NoteFound = "Role_NotFound";
        Task<bool> Create(RoleEntity obj);
        Task<bool> Update(RoleEntity obj);
        Task<bool> Delete(int id);
        Task<List<RoleEntity>> GetAllRoles();
        Task<RoleEntity> GetById(int id);
    }
}
