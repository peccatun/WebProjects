using System.ComponentModel.DataAnnotations;

namespace MySecondTryForum.ViewModels.Topics
{
    public class OpenTopicViewModel
    {
        [Required]
        [MaxLength(50)]
        public string Header { get; set; }

    }
}
