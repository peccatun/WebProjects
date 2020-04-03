﻿using System;
using System.ComponentModel.DataAnnotations;

namespace HealthyEnvironment.Models
{
    public class Solution
    {
        public Solution()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        [Display(Name = "Reply")]
        public string Content { get; set; }

        public byte[] Image { get; set; }

        public DateTime PostedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        public string DiscussionId { get; set; }

        public Discussion Discussion { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
