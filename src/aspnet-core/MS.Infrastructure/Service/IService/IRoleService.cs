using PTS.Domain.Dto;
using PTS.Domain.Entities;

namespace PTS.Host.Service.IService
{
    public interface IRoleService
    {
        public Task<bool> CreatRole(RoleCreateDto p);

        public Task<bool> EditRole(Guid id, RoleUpdateDto roleUpdate);
        public Task<bool> DelRole(Guid id);
        public Task<List<RoleEntity>> GetAllRole();
        public Task<List<RoleEntity>> GetAllRoleActive();
        public Task<RoleEntity> GetRoleById(Guid id);
    }
}