using PTS.Domain.Dto;

namespace PTS.Domain.IService
{
    public interface IAccountService
    {
        Task<LoginResponse> Login(string username, string password);
    }
}
