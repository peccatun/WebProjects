using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskReminder.InputModels
{
    public class EditUnfinishedTaskInputModel
    {
        public int TaskId { get; set; }

        [StringLength(5000, MinimumLength = 0,
                    ErrorMessage = "{0} lenght must be between {2} and {1} characters long.")]
        [Required]
        [Display(Name = "Content")]
        public string Content { get; set; }

        [Display(Name = "Expire day")]
        public DateTime ExpireDate { get; set; }

        [Display(Name = "Expire time")]
        public DateTime ExpireTime { get; set; }
    }
}
