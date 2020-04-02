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
        [StringLength(500, ErrorMessage = "The {0} must be between {2} and {1} characters.", MinimumLength = 1)]
        public string AdditionalInfo { get; set; }

        [Required]
        public byte[] Image { get; set; }

        public DateTime OpenedOn { get; set; }

        public DateTime? ClosedOn { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsApproved { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        //TODO: Decide what will you do with DiscussionCategory

        public IEnumerable<DiscussionCategory> DiscussionCategories { get; set; }

        public IEnumerable<Solution> Solutions { get; set; } = new HashSet<Solution>();
    }
}
