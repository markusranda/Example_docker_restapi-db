using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;

namespace Supermarket.API.Domain.Repositories
{
    public interface IHighscoreRepository
    {
        Task<IEnumerable<Highscore>> ListAsync();

        Task SaveAsync(Highscore highscore);
    }
}