using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Persistence.Contexts;

namespace Supermarket.API.Persistence.Repositories
{
    public class HighscoreRepository : BaseRepository, IHighscoreRepository
    {
        public HighscoreRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Highscore>> ListAsync()
        {
            return await _context.Highscores.ToListAsync();
        }

        public async Task SaveAsync(Highscore highscore)
        {
            await _context.Highscores.AddAsync(highscore);
        }
    }
}