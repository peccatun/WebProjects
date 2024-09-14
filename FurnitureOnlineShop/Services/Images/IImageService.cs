using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace FurnitureOnlineShop.Services.Images
{
    public interface IImageService
    {
        Task<int> SaveImageToDbAsync(IFormFile file);

        string GetImagePathByImageId(int imageId);

        byte[] GetImageBytes(int imageId);

        Task DeleteImageByIdAsync(int imageId);
    }
}
