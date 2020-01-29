using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Domain.Services;
using Supermarket.API.Domain.Services.Communication;

namespace Supermarket.API.Services
{
    public class HighscoreService : IHighscoreService
    {
        private readonly IHighscoreRepository _highscoreRepository;
        private readonly IUnitOfWork _unitOfWork;

        public HighscoreService(IHighscoreRepository highscoreRepository, IUnitOfWork unitOfWork)
        {
            _highscoreRepository = highscoreRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Highscore>> ListAsync()
        {
            return await _highscoreRepository.ListAsync();
        }

        public async Task<HighscoreResponse> SaveAsync(Highscore highscore)
        {
            try
            {
                await _highscoreRepository.SaveAsync(highscore);
                await _unitOfWork.CompleteAsync();
                
                return new HighscoreResponse(highscore);
            }
            catch (Exception e)
            {
                // todo implement logging
                return new HighscoreResponse(
                    $"An error occured when saving the highscore: {e.Message}");
            }
        }
    }
}