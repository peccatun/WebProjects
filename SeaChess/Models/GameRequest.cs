namespace SeaChess.Models
{
    public class GameRequest
    {
        public long Id { get; set; }

        public bool IsDeleted { get; set; }

        public string ApplicationUserId { get; set; }
    }
}
