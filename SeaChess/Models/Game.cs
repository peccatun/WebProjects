using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeaChess.Models
{
    public class Game
    {
        public long Id { get; set; }

        public bool IsDel { get; set; }

        [Required]
        public string PlayerOneId { get; set; }

        [NotMapped]
        public virtual ApplicationUser ApplicationUserOne { get; set; }

        [Required]
        public string PlayerTwoId { get; set; }

        [NotMapped]
        public  virtual ApplicationUser ApplicatonUserTwo { get; set; }

        public int GameStateId { get; set; }

        [NotMapped]
        public virtual GameState GameState { get; set; }

    }
}
