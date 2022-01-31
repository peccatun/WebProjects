using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeaChess.Models
{
    public class GameSign
    {
        public long Id { get; set; }

        public bool IsDel { get; set; }

        public long GameId { get; set; }

        [StringLength(10)]
        public string PlayerOneSign { get; set; }

        public string PlayerOneId { get; set; }

        [NotMapped]
        public virtual ApplicationUser ApplicationUserOne { get; set; }

        [StringLength(10)]
        public string PlayerTwoSign { get; set; }

        public string PlayerTwoId { get; set; }

        [NotMapped]
        public virtual ApplicationUser ApplicationUserTwo { get; set; }
    } 
}
