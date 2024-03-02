using PTS.Domain.Dto;

namespace PTS.Host.Service.IService
{
    public interface ISendMailService
    {
        Task SendMail(EmailDto mailContent);
    }
}
