using ImageViewer.InputModels.Images;
using ImageViewer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageViewer.Controllers
{
    public class ImagesController : Controller
    {
        private readonly IImageService imageService;

        public ImagesController(IImageService imageService)
        {
            this.imageService = imageService;
        }

        public IActionResult Upload() 
        {
            return View();
        }

        [HttpPost]
        [RequestSizeLimit(100 * 1024 * 1024)]
        public async Task<IActionResult> Upload(IFormFile[] images) 
        {
            if (images.Length > 10)
            {
                ModelState.AddModelError("images", "error");
            }

            if (images.Any(i => i.Length > 10 * 1024 * 1024))
            {
                ModelState.AddModelError("images", "error");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            await imageService.ProcessToDb(images.Select(i => new ImageInputModel
            {
                Name = i.FileName,
                Type = i.ContentType,
                Content = i.OpenReadStream(),
            }));

            return RedirectToAction("Index","Home");
        }

        public async Task<IActionResult> All() 
        {
            return View(await imageService.GetAllImages());
        }


        public async Task<IActionResult> Thumbnail(string id) 
        {
            return File(await imageService.GetThumbnail(id), "image/jpeg");
        }

        public async Task<IActionResult> Fullscreen(string id)
        {
            return File(await imageService.GetFullscreen(id), "image/jpeg");
        }

        public async Task<IActionResult> Original(string id)
        {
            return File(await imageService.GetOriginal(id), "image/jpeg");
        }
    }
}
