using System.ComponentModel.DataAnnotations;

namespace HealthyEnvironment.ViewModels.Comments
{
    public class CreateComentViewModel
    {

        public string InformationId { get; set; }

        public string ApplicationUserId { get; set; }

        [Required]
        [Display(Name = "Comment")]
        [StringLength(1000, ErrorMessage = "The {0} must be between {2} and {1} characters.", MinimumLength = 0)]
        public string Content { get; set; }
    }
}
