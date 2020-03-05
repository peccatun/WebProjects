using System.ComponentModel.DataAnnotations;

namespace MySecondTryForum.ViewModels.Topics
{
    public class OpenTopicViewModel
    {
        [Required]
        [StringLength(maximumLength:100,MinimumLength =4,ErrorMessage ="Topic cannot be less than {2} or more than {1} characters.")]
        public string Header { get; set; }

    }
}
