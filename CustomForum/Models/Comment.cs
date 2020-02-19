using System;
using System.ComponentModel.DataAnnotations;

namespace CustomForum.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public DateTime PostedOn { get; set; }

        [Required]
        public string Content { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int TopicId { get; set; }

        public Topic Topic { get; set; }
    }
}
