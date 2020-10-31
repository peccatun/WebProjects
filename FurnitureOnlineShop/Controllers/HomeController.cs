using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FurnitureOnlineShop.Models;
using FurnitureOnlineShop.Services.Categories;
using FurnitureOnlineShop.ViewModels.Categories;

namespace FurnitureOnlineShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoriesService categoriesService;

        public HomeController(ILogger<HomeController> logger, ICategoriesService categoriesService)
        {
            _logger = logger;
            this.categoriesService = categoriesService;
        }

        public IActionResult Index()
        {
            AllCategoriesViewModel model = categoriesService.GetAllCategories();

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
