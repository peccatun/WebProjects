using System.ComponentModel.DataAnnotations;

namespace MotMaintOnline4.InputModels.ApplicationUser
{
    public class ApplicationUserInputModel
    {
        [Required]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Потребителското име трябва да бъде межди {1} и {1} символа")]
        public string Name { get; set; }
    }
}
