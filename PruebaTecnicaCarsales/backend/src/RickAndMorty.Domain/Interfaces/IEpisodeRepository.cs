using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RickAndMorty.Domain.Entities; 
namespace RickAndMorty.Domain.Interfaces
{
    public interface IEpisodeRepository
    {
        Task<PagedResult<Episode>> GetAllAsync(int page, string? name = null, string? episode = null);
        Task<Episode?> GetByIdAsync(int id);
        Task<List<Episode>> GetMultipleByIdsAsync(List<int> ids);
    }   
}   