using PTS.Domain.Dto;

namespace PTS.Host.Service.IService
{
    public interface IAccountService
    {
        Task<ServiceResponse> Login(string username, string password);
    }
}
