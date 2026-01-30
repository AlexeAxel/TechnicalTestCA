using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RickAndMorty.Application.Interfaces;


namespace RickAndMorty.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EpisodesController : ControllerBase
    {
        private readonly IEpisodeService _episodeService;
        private readonly ILogger<EpisodesController> _logger;

        public EpisodesController(IEpisodeService episodeService, ILogger<EpisodesController> logger)
        {
            _episodeService = episodeService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetEpisodes(
            [FromQuery] int page = 1,
            [FromQuery] string? name = null,
            [FromQuery] string? episode = null)
        {
            _logger.LogInformation("Getting episodes - Page: {Page}, Name: {Name}, Episode: {Episode}", page, name, episode);
            
            var result = await _episodeService.GetEpisodesAsync(page, name, episode);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEpisode(int id)
        {
            _logger.LogInformation("Getting episode by ID: {Id}", id);
            
            var episode = await _episodeService.GetEpisodeByIdAsync(id);
            
            if (episode == null)
                return NotFound(new { message = $"Episode with ID {id} not found" });

            return Ok(episode);
        }
    }
}