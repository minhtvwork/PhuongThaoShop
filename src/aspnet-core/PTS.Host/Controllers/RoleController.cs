using Microsoft.AspNetCore.Mvc;
using PTS.Domain.Dto;
using PTS.Domain.Entities;
using PTS.Host.Service.IService;

namespace PTS.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        private readonly IConfiguration _config;
        public RoleController(IRoleService roleService, IConfiguration config)
        {
            _roleService = roleService;
            _config = config;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {

            //string apiKey = _config.GetSection("ApiKey").Value;
            //if (apiKey == null)
            //{
            //    return Unauthorized();
            //}

            //var keyDomain = Request.Headers["Key-Domain"].FirstOrDefault();
            //if (keyDomain != apiKey.ToLower())
            //{
            //    return Unauthorized();
            //}
            return Ok(await _roleService.GetAllRole());
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleEntity obj)
        {
            string apiKey = _config.GetSection("ApiKey").Value;
            //if (apiKey == null)
            //{
            //    return Unauthorized();
            //}

            //var keyDomain = Request.Headers["Key-Domain"].FirstOrDefault();
            //if (keyDomain != apiKey.ToLower())
            //{
            //    return Unauthorized();
            //}
            var roleCreate = new RoleCreateDto()
            {
                Name = obj.RoleName,
                concurrencyStamp = Guid.NewGuid().ToString(),
            };

            try
            {
                var result = await _roleService.CreatRole(roleCreate);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPut("id")]
        public async Task<IActionResult> UpdateRole(Guid id, RoleUpdateDto roleUpdateDto)
        {

            string apiKey = _config.GetSection("ApiKey").Value;
            if (apiKey == null)
            {
                return Unauthorized();
            }

            var keyDomain = Request.Headers["Key-Domain"].FirstOrDefault();
            if (keyDomain != apiKey.ToLower())
            {
                return Unauthorized();
            }
            try
            {
                var result = await _roleService.EditRole(id, roleUpdateDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteRole(Guid id)
        {

            string apiKey = _config.GetSection("ApiKey").Value;
            if (apiKey == null)
            {
                return Unauthorized();
            }

            var keyDomain = Request.Headers["Key-Domain"].FirstOrDefault();
            if (keyDomain != apiKey.ToLower())
            {
                return Unauthorized();
            }
            try
            {
                var reuslt = await _roleService.DelRole(id);
                return Ok(reuslt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
