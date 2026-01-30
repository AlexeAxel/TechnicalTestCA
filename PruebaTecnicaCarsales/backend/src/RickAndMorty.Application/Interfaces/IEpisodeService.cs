using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RickAndMorty.Application.DTOs;

namespace RickAndMorty.Application.Interfaces
{
public interface IEpisodeService
{
    Task<PagedEpisodeDto> GetEpisodesAsync(int page = 1, string? name = null, string? episode = null);
    Task<EpisodeDto?> GetEpisodeByIdAsync(int id);
}
}