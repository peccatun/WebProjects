using System;

namespace SeaChess.Dto
{
    public class GameRequestDto
    {
        public long Id { get; set; }

        public string ApplicationUserId { get; set; }

        public DateTime RequestDate { get; set; }
    }
}
