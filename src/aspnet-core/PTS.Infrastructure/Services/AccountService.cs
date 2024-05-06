using Microsoft.IdentityModel.Tokens;
using PTS.Core.Dto;
using PTS.Core.Entities;
using PTS.Core.Repositories;
using PTS.Core.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PTS.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<LoginResponse> Login(string username, string password)
        {
            try
            {
                var user = await _userRepository.GetUserByUsername(username);
                if (user.Username != username)
                {
                    return new LoginResponse(false,null,null,null,null,null,null, false,null);
                }

                if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                {
                    return new LoginResponse(false, null, null, null, null, null, null, false, null);
                }

                string token = CreateToken(user);
                if (user.RoleEntities.RoleName == "admin")
                {
                    return new LoginResponse(true, user.Username, user.FullName, user.PhoneNumber, user.Address, user.Email, user.RoleEntities.RoleName, true, token);
                }
                return new LoginResponse(true, user.Username, user.FullName, user.PhoneNumber, user.Address, user.Email, user.RoleEntities.RoleName, false, token);
            }
            catch (Exception)
            {
                return new LoginResponse(false, null, null, null, null, null, null, false, null);
            }
        }
        private string CreateToken(UserEntity user)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Role, user.RoleEntities.RoleName),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("PTS KMM BMK 1038 MPTM PTS KMM BMK 1038 MPTM"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
