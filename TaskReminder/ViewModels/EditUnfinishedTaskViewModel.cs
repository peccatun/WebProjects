using System;
using System.ComponentModel.DataAnnotations;

namespace TaskReminder.ViewModels
{
    public class EditUnfinishedTaskViewModel
    {
        public int TaskId { get; set; }

        [StringLength(5000, MinimumLength = 0,
            ErrorMessage = "{0} lenght must be between {2} and {1} characters long.")]
        [Required]
        [Display(Name = "Content")]
        public string Content { get; set; }

        [Display(Name = "Expire day")]
        public DateTime ExpireDate { get; set; }
    }
}
