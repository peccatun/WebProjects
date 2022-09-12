namespace FurnitureOnlineShop.Controllers
{
    using FurnitureOnlineShop.Services.Images;
    using Microsoft.AspNetCore.Mvc;

    public class ImageController : Controller
    {
        private readonly IImageService imageService;

        public ImageController(IImageService imageService)
        {
            this.imageService = imageService;
        }

        public IActionResult GetImage(int id) 
        {
            return File(imageService.GetImageBytes(id), "image/jpeg");
        }
    }
}
