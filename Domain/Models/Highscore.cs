namespace Supermarket.API.Domain.Models
{
    public class Highscore
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double HighScore { get; set; }
        public string Resolution { get; set; }
    }
}