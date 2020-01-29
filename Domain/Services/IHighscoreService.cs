using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services.Communication;

namespace Supermarket.API.Domain.Services
{
    public interface IHighscoreService
    {
        Task<IEnumerable<Highscore>> ListAsync();
        Task<HighscoreResponse> SaveAsync(Highscore highscore);
    }
}