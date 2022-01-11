using System.ComponentModel.DataAnnotations;

namespace SeaChess.Models
{
    public class GameSign
    {
        public long Id { get; set; }

        public long GameId { get; set; }

        [StringLength(10)]
        public string PlayerOneSign { get; set; }

        [StringLength(10)]
        public string PlayerTwoSign { get; set; }
    }
}
