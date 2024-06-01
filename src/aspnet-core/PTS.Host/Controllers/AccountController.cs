using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PTS.Application.Dto;
using PTS.Domain.Entities;
using PTS.Core.Repositories;
using PTS.Host.AppCore.Request.Account;
using PTS.Host.AppCore.Request.Voucher;
using PTS.Core.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using App.Helper;

namespace PTS.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAccountService _accountService;
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public AccountController(IConfiguration configuration, IAccountService accountService, IUserRepository userRepository, IMediator mediator, IMapper mapper)
        {
            _configuration = configuration;
           _accountService = accountService;
            _userRepository = userRepository;
            _mediator = mediator;
            _mapper = mapper;
        }
        [AllowAnonymous]
        [HttpPost("CreateOrUpdateAccount")]
        public async Task<IActionResult> CreateOrUpdateAccount(CreateOrUpdateAccountQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDto obj)
        {
            var result = await _accountService.Login(obj.Username, obj.Password);
            if (result.IsSuccess)
            {
              return Ok(result);
            }
            return BadRequest(result);
        }
        [AllowAnonymous]
        [HttpGet("GetMyInfor")]
        public async Task<IActionResult> GetMyInfor()
        {
            var x = AppSettings.RootPath;
            var username = User.Identity.Name;
            return Ok(username);
        }
    }
}
