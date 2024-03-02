//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;

//using PTS.Host.Service.IService;
//using PTS.Domain.Dto;
//using PTS.Domain.Entities;
//using PTS.Data;

//namespace PTS.Host.Service
//{
//    public class RoleService : IRoleService
//    {
//        private readonly ApplicationDbContext _context;
//        private readonly RoleManager<RoleEntity> _roleManager;

//        public RoleService(ApplicationDbContext context, RoleManager<RoleEntity> roleManager)
//        {
//            _roleManager = roleManager;
//            _context = context;
//        }

//        public async Task<bool> CreatRole(RoleCreateDto p)
//        {
//            try
//            {
//                var Role = new RoleEntity()
//                {
//                    Name = p.Name.ToUpper(),
//                    Id = 0,
//                    Status=1,
//                    ConcurrencyStamp = p.concurrencyStamp,
//                    NormalizedName = p.normalizedName,
//                };
//                var result = await _roleManager.CreateAsync(Role);

//                //if (!result.Succeeded)
//                //{
//                //    return new ArgumentException("ád");
//                //        public object? Result { get; set; }
//                //public bool IsSuccess { get; set; } = true;
//                //public int Code { get; set; } = 200;
//                //public string Message { get; set; } = "Thành công";
//                //public int Count { get; set; } = 0;
//                //}
//                //var respone = new ResponseDto()
//                //{
//                //    Result = result,
//                //    IsSuccess=result.Succeeded,
//                //};
//                //if(respone.IsSuccess ) 
//                //{
//                //    respone.Result=result.Errors;
//                //}
//                return result.Succeeded;
//            }
//            catch (Exception ex)
//            {

//                throw new ArgumentException(ex.Message);
//            }
//        }

//        public async Task<bool> DelRole(Guid id)
//        {
//            try
//            {
//                var obj = await _roleManager.FindByIdAsync(id.ToString());
//                obj.Status = 1;
//                await _roleManager.UpdateAsync(obj);
//                return true;
//            }
//            catch (Exception)
//            {

//                return false;
//            }
//        }

//        public async Task<bool> EditRole(Guid id, RoleUpdateDto roleUpdate)
//        {
//            try
//            {
//                var obj = await _roleManager.FindByIdAsync(id.ToString());
//                obj.Status = roleUpdate.status;
//                obj.Name = roleUpdate.Name;
//                obj.NormalizedName = roleUpdate.normalizedName;
//                obj.ConcurrencyStamp = roleUpdate.concurrencyStamp;
//                await _roleManager.UpdateAsync(obj);
//                return true;

//            }
//            catch (Exception)
//            {

//                return false;
//            }
//        }

//        public async Task<List<RoleEntity>> GetAllRole()
//        {
//            var roles = await _roleManager.RoleEntity.ToListAsync();
//            return roles;
//        }

//        public Task<List<RoleEntity>> GetAllRoleActive()
//        {
//            throw new NotImplementedException();
//        }

//        public async Task<RoleEntity> GetRoleById(Guid id)
//        {

//            return await _roleManager.FindByIdAsync(id.ToString());
//        }
//    }
//}
