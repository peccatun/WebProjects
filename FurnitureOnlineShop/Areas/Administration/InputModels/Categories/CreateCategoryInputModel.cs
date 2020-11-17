using System.ComponentModel.DataAnnotations;

namespace FurnitureOnlineShop.Areas.Administration.InputModels.Categories
{
    public class CreateCategoryInputModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "{0} Трябва да бъде между {1} и {2} символа", MinimumLength = 0)]
        [Display(Name = "Име на категорията")]
        public string CategoryName { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "{0} трябва да бъде между {1} и {2}", MinimumLength = 0)]
        [Display(Name = "Описание на продукта")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Картинка на категорията")]
        public string ImageUrl { get; set; }
    }
}
