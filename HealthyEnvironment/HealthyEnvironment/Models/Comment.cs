using System;
using System.ComponentModel.DataAnnotations;

namespace HealthyEnvironment.Models
{
    public class Comment
    {
        public Comment()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        [Required]
        [Display(Name = "Comment")]
        [StringLength(1000, ErrorMessage = "The {0} must be between {2} and {1} characters.", MinimumLength = 0)]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        public string InformationId { get; set; }

        public virtual Information Information { get; set; }
    }
}
