using PTS.Domain.Dto;

namespace PTS.Domain.IService
{
    public interface ISendMailService
    {
        Task SendMail(EmailDto mailContent);
    }
}
