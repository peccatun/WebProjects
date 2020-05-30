using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskReminder.Models
{
    public class Task
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime ExpireDay { get; set; }

        public bool IsCompleated { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
