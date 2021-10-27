using FurnitureOnlineShop.Services.SubCategories;
using FurnitureOnlineShop.ViewModels.SubCategories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureOnlineShop.Controllers
{
    public class SubCategoryController : Controller
    {
        private readonly ISubCategoryService subCategoryService;

        public SubCategoryController(ISubCategoryService subCategoryService)
        {
            this.subCategoryService = subCategoryService;
        }

        public IActionResult SubCategoryItems(long subCategoryId)
        {
            SubCategoryItemsViewModel model = subCategoryService.GetSubCategoryItems(subCategoryId);

            return View(model);
        }
    }
}
