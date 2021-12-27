using System.ComponentModel.DataAnnotations;

namespace SeaChess.Models
{
    public class Game
    {
        public long Id { get; set; }

        public bool IsDel { get; set; }

        [Required]
        public string PlayerOneId { get; set; }

        [Required]
        public string PlayerTwoId { get; set; }

        public int GameStateId { get; set; }

        public virtual GameState GameState { get; set; }

    }
}
