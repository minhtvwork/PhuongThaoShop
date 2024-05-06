using PTS.Core.Dto;
using PTS.Core.Entities;

namespace PTS.Infrastructure.Services
{
    public interface IImagesServies
    {
        //Task<string> UploadImages(IFormFile file, string c);
        Task<int> SaveImageAsync(ImageEntity image);
    }
}
