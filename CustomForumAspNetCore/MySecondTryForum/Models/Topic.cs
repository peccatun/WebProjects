using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MySecondTryForum.Models
{
    public class Topic
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Header { get; set; }

        public DateTime OpenedOn { get; set; }

        public DateTime? ClosedOn { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicatuinUser { get; set; }

        public bool IsClosed { get; set; }

        public IEnumerable<Comment> Comments { get; set; } = new HashSet<Comment>();
    }
}
