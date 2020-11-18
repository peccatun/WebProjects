using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace FurnitureOnlineShop.Services.CategoryImages
{
    public interface ICategoryImageService
    {
        Task<int> SaveCategoryImageToDb(IFormFile file);

        string GetImagePathByImageId(int categoryImageId);
    }
}
