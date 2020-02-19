using System;
using System.Collections.Generic;

namespace CustomForum.Models
{
    public class Topic
    {
        public int Id { get; set; }

        public DateTime StartedOn { get; set; }

        public DateTime ClosedOn { get; set; }

        public bool IsOpened { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
    }
}
