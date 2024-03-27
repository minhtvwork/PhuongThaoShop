using PTS.Domain.Dto;

namespace PTS.Host.Service.IService
{
    public interface IAccountService
    {
        Task<LoginResponse> Login(string username, string password);
    }
}
