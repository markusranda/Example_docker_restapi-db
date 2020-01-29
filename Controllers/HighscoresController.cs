using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services;
using Supermarket.API.Extensions;
using Supermarket.API.Resources;

namespace Supermarket.API.Controllers
{
    [Route("/api/[controller]")]
    public class HighscoresController : Controller
    {
        private readonly IHighscoreService _highscoreService;
        private readonly IMapper _mapper;

        public HighscoresController(IHighscoreService highscoreService, IMapper mapper)
        {
            _highscoreService = highscoreService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<Highscore>> GetAllAsync()
        {
            var highscores = await _highscoreService.ListAsync();
            return highscores;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveHighscoreResource resource)
        {
            // Check if the user data works with this model
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var highscore = _mapper.Map<SaveHighscoreResource, Highscore>(resource);

            var result = await _highscoreService.SaveAsync(highscore);

            if (!result.Success) return BadRequest(result.Message);

            var highscoreResource = _mapper.Map<Highscore, HighscoreResource>(result.Highscore);
            return Ok(highscoreResource);
        }
    }
}