using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RickAndMorty.Application.DTOs;
using RickAndMorty.Application.Interfaces;
using RickAndMorty.Domain.Interfaces;

namespace RickAndMorty.Application.Services
{
    public class EpisodeService : IEpisodeService
    {
        private readonly IEpisodeRepository _episodeRepository;

        public EpisodeService(IEpisodeRepository episodeRepository)
        {
            _episodeRepository = episodeRepository;
        }

        public async Task<PagedEpisodeDto> GetEpisodesAsync(int page = 1, string? name = null, string? episode = null)
        {
            var result = await _episodeRepository.GetAllAsync(page, name, episode);

            return new PagedEpisodeDto(
                new PageInfoDto(
                    result.Info.Count,
                    result.Info.Pages,
                    result.Info.Next,
                    result.Info.Prev,
                    page
                ),
                result.Results.Select(e => new EpisodeDto(
                    e.Id,
                    e.Name,
                    e.AirDate,
                    e.EpisodeCode,
                    e.Characters,
                    e.Url,
                    e.Created
                )).ToList()
            );
        }

        public async Task<EpisodeDto?> GetEpisodeByIdAsync(int id)
        {
            var episode = await _episodeRepository.GetByIdAsync(id);
            
            if (episode == null)
                return null;

            return new EpisodeDto(
                episode.Id,
                episode.Name,
                episode.AirDate,
                episode.EpisodeCode,
                episode.Characters,
                episode.Url,
                episode.Created
            );
        }
    }
}