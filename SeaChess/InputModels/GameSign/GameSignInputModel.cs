namespace SeaChess.InputModels.GameSign
{
    public class GameSignInputModel
    {
        public long GameId { get; set; }

        public string PlayerOneId { get; set; }

        public string PlayerOneSign { get; set; }

        public string PlayerTwoId { get; set; }

        public string PlayerTwoSign { get; set; }
    }
}
