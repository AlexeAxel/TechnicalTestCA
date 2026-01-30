using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RickAndMorty.Domain.Entities;

namespace RickAndMorty.Domain.Interfaces
{
    public interface ICharacterRepository
    {
        Task<PagedResult<Character>> GetAllAsync(int page, string? name = null, string? status = null, string? species = null, string? gender = null);
        Task<Character?> GetByIdAsync(int id);
        Task<List<Character>> GetMultipleByIdsAsync(List<int> ids);
    }
}