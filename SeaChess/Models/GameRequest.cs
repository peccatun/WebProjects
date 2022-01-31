using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeaChess.Models
{
    public class GameRequest
    {
        public long Id { get; set; }

        public bool IsDeleted { get; set; }

        public bool HasPlayed { get; set; }

        public string ApplicationUserId { get; set; }

        [NotMapped]
        public virtual ApplicationUser ApplicationUser { get; set; }

        public DateTime RequestDate { get; set; }
    }
}
