using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace PTS.Host.Controllers
{

    //[Route("[controller]/[action]")]
    //public class SecurityRoles
    //{
    //    public const string Admin = "Admin";
    //    public const string Manager = "Manager";
    //    public const string User = "User";

    //    public static readonly IList<string> Roles = new ReadOnlyCollection<string>
    //    (new List<string>
    //    {
    //    Admin,
    //    Manager,
    //    User
    //    });
    //}
    //public class PermissionController : ControllerBase
    //{
    //    [Authorize(Roles = SecurityRoles.Admin)]
    //    [HttpGet]
    //    public IActionResult AdminRole()
    //    {
    //        return Ok("Hello Admin");
    //    }

    //    [Authorize(Roles = SecurityRoles.Manager)]
    //    [HttpGet]
    //    public IActionResult ManagerRole()
    //    {
    //        return Ok("Hello Manager");
    //    }

    //    [Authorize(Roles = SecurityRoles.User)]
    //    [HttpGet]
    //    public IActionResult UserRole()
    //    {
    //        return Ok("Hello User");
    //    }
    //}
}
