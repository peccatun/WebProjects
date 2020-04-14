using System;
using System.ComponentModel.DataAnnotations;

namespace HealthyEnvironment.Models
{
    public class Information
    {
        public Information()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Display(Name = "ImageUrl")]
        public string ImageUrl { get; set; }

        [Required]
        [Display(Name = "About")]
        [StringLength(50,  ErrorMessage = "The {0} must be between {2} and {1} characters.", MinimumLength = 4)]
        public string About { get; set; }

        [Required]
        [Display(Name = "Information content")]
        [StringLength(5000, ErrorMessage = "The {0} must be between {2} and {1} characters.", MinimumLength = 20)]
        public string Content { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        public string CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
