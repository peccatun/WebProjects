using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SeaChess.Models
{
    public class GameState
    {
        public int Id { get; set; }

        public bool IsDel { get; set; }

        [Required]
        public string State { get; set; }

        public virtual IEnumerable<Game> Games { get; set; }
    }
}
