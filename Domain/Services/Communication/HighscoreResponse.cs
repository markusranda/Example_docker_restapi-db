using Supermarket.API.Domain.Models;

namespace Supermarket.API.Domain.Services.Communication
{
    public class HighscoreResponse : BaseResponse
    {
        public Highscore Highscore { get; set; }
        
        public HighscoreResponse(bool success, string message, Highscore highscore) : base(success, message)
        {
            Highscore = highscore;
        }
        
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="category">Saved category.</param>
        /// <returns>Response.</returns>
        public HighscoreResponse(Highscore highscore) : this(true, string.Empty, highscore)
        {
        }
        
        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public HighscoreResponse(string message) : this(false, message, null)
        {
        }
    }
}