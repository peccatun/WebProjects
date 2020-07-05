using System;
using System.ComponentModel.DataAnnotations;

namespace TaskReminder.InputModels
{
    public class CreateTaskInputModel
    {
        [StringLength(5000, MinimumLength = 0,
            ErrorMessage = "{0} lenght must be between {2} and {1} characters long.")]
        [Required]
        [Display(Name = "Content")]
        public string Content { get; set; }

        [Display(Name = "Expire day")]
        public DateTime ExpireDay { get; set; }

        [Display(Name = "Expire time")]
        public DateTime ExpireTime { get; set; }

        public string ApplicationUserId { get; set; }
    }
}
