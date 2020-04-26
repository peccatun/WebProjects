using HealthyEnvironment.Areas.Administration.Services;
using HealthyEnvironment.Areas.Administration.ViewModels.Products;
using HealthyEnvironment.Services.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HealthyEnvironment.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        private readonly ICategoriesService categoriesService;
        private readonly IProductsServiceAdmin productsServiceAdmin;

        public ProductsController(
            ICategoriesService categoriesService,
            IProductsServiceAdmin productsServiceAdmin
            )
        {
            this.categoriesService = categoriesService;
            this.productsServiceAdmin = productsServiceAdmin;
        }

        [HttpGet]
        public IActionResult ProductsMenu()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            CreateProductViewModel model = new CreateProductViewModel();
            model.Categories = this.categoriesService.GetCategoryNameAndId();

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = this.categoriesService.GetCategoryNameAndId();
                return this.View(model);
            }

            await this.productsServiceAdmin.CreateProductAsync(model);

            return this.Redirect("/");
        }
         
    }
}
