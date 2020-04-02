﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HealthyEnvironment.Models
{
    public class Category
    {
        public Category()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        [StringLength(30, ErrorMessage = "The {0} must be between {2} and {1} characters.", MinimumLength = 4)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Image")]
        public byte[] Image { get; set; }

        public bool IsApproved { get; set; }

        public IEnumerable<Information> Informations { get; set; } = new HashSet<Information>();

        public IEnumerable<Discussion> Discussions { get; set; } = new HashSet<Discussion>();
    }
}
