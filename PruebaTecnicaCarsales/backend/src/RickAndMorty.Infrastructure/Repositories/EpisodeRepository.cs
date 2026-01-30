using System.Net.Http.Json;
using RickAndMorty.Domain.Entities;
using RickAndMorty.Domain.Interfaces;
using Microsoft.Extensions.Options;
using RickAndMorty.Infrastructure.Configuration;

namespace RickAndMorty.Infrastructure.Repositories{

public class EpisodeRepository : IEpisodeRepository
{
    private readonly HttpClient _httpClient;
        private readonly RickAndMortyApiSettings _settings;

        public EpisodeRepository(HttpClient httpClient, IOptions<RickAndMortyApiSettings> settings)
        {
            _httpClient = httpClient;
            _settings = settings.Value;
        }

        public async Task<PagedResult<Episode>> GetAllAsync(int page, string? name = null, string? episode = null)
        {
            var queryParams = new List<string> { $"page={page}" };
            
            if (!string.IsNullOrWhiteSpace(name))
                queryParams.Add($"name={Uri.EscapeDataString(name)}");
            
            if (!string.IsNullOrWhiteSpace(episode))
                queryParams.Add($"episode={Uri.EscapeDataString(episode)}");

            var query = string.Join("&", queryParams);
            var response = await _httpClient.GetFromJsonAsync<PagedResult<Episode>>($"episode?{query}");

            return response ?? new PagedResult<Episode>();
        }

        public async Task<Episode?> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Episode>($"episode/{id}");
        }

        public async Task<List<Episode>> GetMultipleByIdsAsync(List<int> ids)
        {
            var idsString = string.Join(",", ids);
            var response = await _httpClient.GetFromJsonAsync<List<Episode>>($"episode/{idsString}");
            return response ?? new List<Episode>();
        }
    }
}