using FurnitureOnlineShop.Areas.Administration.ViewModels.Categories;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FurnitureOnlineShop.Areas.Administration.InputModels.Categories
{
    public class CreateSubCategoryInputModel
    {
        [Required]
        [Display(Name = "Заглавие на под категория")]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "{0} трябва да е между {1} и {2} символа.")]
        public string SubCategoryName { get; set; }

        [Required]
        [Display(Name = "Категория")]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryDropDownMenuViewModel> CategoryDropDownMenu { get; set; }

    }
}
