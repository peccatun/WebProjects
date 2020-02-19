using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CustomForum.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public DateTime BirthDate { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

        public IEnumerable<Topic> Topics { get; set; }
    }
}
