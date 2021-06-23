namespace FreeGaming.Data.Models
{
    public class UserGame
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public int GameId { get; set; }

        public Game Game { get; set; }

        public decimal TimePlayed { get; set; }
    }
}
