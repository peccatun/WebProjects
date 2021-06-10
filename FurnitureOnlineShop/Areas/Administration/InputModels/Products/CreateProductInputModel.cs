using FurnitureOnlineShop.Areas.Administration.InputModels.Categories;
using FurnitureOnlineShop.Areas.Administration.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FurnitureOnlineShop.Areas.Administration.InputModels.Products
{
    public class CreateProductInputModel
    {
        [Required]
        [Display(Name = "Име на продукта")]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "{0} трябва да е между {2} и {1} символа!")]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "Описание")]
        [StringLength(500, MinimumLength = 0, ErrorMessage = "{0} трябва да е между {2} и {1} символа!")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Цвят")]
        public int ColorId { get; set; }

        [Required]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [Display(Name = "Налични бройки")]
        public int Quantity { get; set; }

        [Display(Name = "Категория")]
        public int CategoryId { get; set; }

        [Display(Name = "ПодКатегория")]
        public int SubCategoryId { get; set; }

        [Display(Name = "Снимка на продукта")]
        public IFormFile ProductImagePath { get; set; }

        public IEnumerable<CategoryDropDownMenuItemViewModel> Categories { get; set; } = new HashSet<CategoryDropDownMenuItemViewModel>();

        public IEnumerable<ColorViewModel> Colors { get; set; } = new HashSet<ColorViewModel>();
    }
}
