using System.ComponentModel.DataAnnotations;

namespace Supermarket.API.Resources
{
    public class SaveHighscoreResource
    {
        [Required] [MaxLength] public string Name { get; set; }
        [Required] public double Highscore { get; set; }
        [Required] [MaxLength] public string Resolution { get; set; }
    }
}