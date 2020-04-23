using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HealthyEnvironment.Models
{
    public class Discussion
    {
        public Discussion()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        [Display(Name = "About")]
        [StringLength(50, ErrorMessage = "The {0} must be between {2} and {1} characters.", MinimumLength = 5)]
        public string About { get; set; }

        [Required]
        [Display(Name = "Additional Info")]
        [StringLength(10000, ErrorMessage = "The {0} must be between {2} and {1} characters.", MinimumLength = 1)]
        public string AdditionalInfo { get; set; }

        [Required]
        [Display(Name ="ImageUrl")]
        public string ImageUrl { get; set; }

        public DateTime OpenedOn { get; set; }

        public DateTime? ClosedOn { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsApproved { get; set; }

        [Required]
        public string CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual IEnumerable<Solution> Solutions { get; set; } = new HashSet<Solution>();
    }
}
