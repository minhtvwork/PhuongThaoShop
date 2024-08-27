using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PTS.Application.Dto;
using PTS.Domain.Entities;
using PTS.Application.Interfaces.Repositories;
using PTS.Core.Services;
using PTS.Application.Features.Account.Commands;
using PTS.Application.Features.Account.Queries;
using PTS.WebAPI.Model;
using PTS.Application.Features.Bill.DTOs;
using PTS.Domain.Model.Base;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace PTS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
		private readonly UserManager<UserEntity> _userManager;
		private readonly SignInManager<UserEntity> _signInManager;
		private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public AccountController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager,IConfiguration configuration, IMediator mediator, IMapper mapper)
        {
			_userManager = userManager;
			_signInManager = signInManager;
			_configuration = configuration;
            _mediator = mediator;
            _mapper = mapper;
        }
        //[AllowAnonymous]
        //[HttpPost("Register")]
        //public async Task<IActionResult> Register([FromBody] RegisterDto model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var user = new UserEntity
        //    {
        //        UserName = model.UserName,
        //        Email = model.Email
        //    };

        //    var result = await _userManager.CreateAsync(user, model.Password);

        //    if (result.Succeeded)
        //    {
        //        return Ok(new { message = "User registered successfully." });
        //    }

        //    return BadRequest(result.Errors.Select(e => e.Description).ToList());
        //}
        [AllowAnonymous]
        [HttpPost("CreateOrUpdateAccount")]
        public async Task<IActionResult> CreateOrUpdateAccount(CreateOrUpdateAccountQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
		[AllowAnonymous]
		[HttpPost("Login")]
		public async Task<IActionResult> Login(LoginQuery query)
		{
			return Ok(await _mediator.Send(query));
		}
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Thông tin nhập thiếu");
            }

            if (!IsValidPhoneNumber(model.PhoneNumber))
            {
                return BadRequest("Sai định đạng số điện thoại");
            }

            var existingUserByUsername = await _userManager.FindByNameAsync(model.UserName);
            if (existingUserByUsername != null)
            {
                return BadRequest("Tài khoản đã tồn tại.");
            }

            var existingUserByEmail = await _userManager.FindByEmailAsync(model.Email);
            if (existingUserByEmail != null)
            {
                return BadRequest("Địa chỉ Email đã tồn tại");
            }

            if (!IsPasswordStrong(model.Password))
            {
                return BadRequest("Mật khẩu không hợp lệ");
            }

            var user = new UserEntity
            {
                UserName = model.UserName,
                Email = model.Email,
                FullName = model.FullName,
                PhoneNumber = model.PhoneNumber,
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(user, "Customer");

                if (roleResult.Succeeded)
                {
                    return Ok("Đăng ký tài khoản thành công");
                }

                return Ok("Đăng ký tài khoản thành công");
            }
            return Ok("Đăng ký tài khoản thành công");
        }

        private bool IsPasswordStrong(string password)
        {
            if (password.Length < 8) return false;
            if (!password.Any(char.IsUpper)) return false;
            if (!password.Any(char.IsLower)) return false;
            if (!password.Any(char.IsDigit)) return false;
            if (!password.Any(char.IsSymbol) && !password.Any(char.IsPunctuation)) return false;
            return true;
        }
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
                return false;
            var regex = new System.Text.RegularExpressions.Regex(@"^(03|05|07|08|09|01[2|6|8|9])+([0-9]{8})\b");
            return regex.IsMatch(phoneNumber);
        }

        [HttpPost("Logout")]
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return Ok(new { message = "Đã đăng xuất thành công" });
		}
		[AllowAnonymous]
        [HttpGet("GetMyInfor")]
        public async Task<IActionResult> GetMyInfor(string userName)
        {
        var x = await _userManager.FindByNameAsync(userName);
            return Ok(x);
        }
        [HttpPost("isAdmin")]
       // [Authorize]
        public async Task<IActionResult> IsAdmin()
        {
            //var user = await _userManager.GetUserAsync(User);
            //if (user == null)
            //{
            //    return Unauthorized();
            //}

            //var roles = await _userManager.GetRolesAsync(user);
            //var isAdmin = roles.Contains("Admin");
            //return Ok(isAdmin);
            return Ok(true);
        }
        [HttpPost("check-permission")]
        public async Task<IActionResult> CheckPermission([FromBody] string token)
        {
            // Validate token
            var principal = GetPrincipalFromToken(token);
            if (principal == null)
            {
                return Unauthorized();
            }

            // Check permissions (role or claims)
            var hasPermission = principal.HasClaim(c => c.Type == ClaimTypes.Role && c.Value == "Admin");

            return Ok(hasPermission);
        }

        private ClaimsPrincipal GetPrincipalFromToken(string token)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = _configuration["Jwt:Issuer"],
                    ValidAudience = _configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]))
                };

                var principal = handler.ValidateToken(token, validationParameters, out var securityToken);
                return principal;
            }
            catch
            {
                return null;
            }
        }
        [HttpGet("GetUserRoles")]
        public async Task<IActionResult> GetUserRoles( string username = null)
        {
            if ( string.IsNullOrEmpty(username))
            {
                return BadRequest("You must provide either userId or username.");
            }

            UserEntity user = null;
                user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var roles = await _userManager.GetRolesAsync(user);
            return Ok(roles);
        }
    }
}
