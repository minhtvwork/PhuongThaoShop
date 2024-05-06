using PTS.Core.Dto;

namespace PTS.Core.Services
{
    public interface IAccountService
    {
        Task<LoginResponse> Login(string username, string password);
    }
}
