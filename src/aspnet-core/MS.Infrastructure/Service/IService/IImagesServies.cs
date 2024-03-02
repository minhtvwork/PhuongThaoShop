using PTS.Domain.Dto;
using PTS.Domain.Entities;

namespace PTS.Host.Services.IServices
{
    public interface IImagesServies
    {
        //Task<string> UploadImages(IFormFile file, string c);
        Task<int> SaveImageAsync(ImageEntity image);
    }
}
