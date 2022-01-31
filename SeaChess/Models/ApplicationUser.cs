using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeaChess.Models
{
    public class ApplicationUser : IdentityUser
    {
        [NotMapped]
        public virtual IEnumerable<GameRequest> GameRequests { get; set; } = new HashSet<GameRequest>();

        [NotMapped]
        public virtual IEnumerable<GameSign> GameSigns { get; set; } = new HashSet<GameSign>();
    }
}
