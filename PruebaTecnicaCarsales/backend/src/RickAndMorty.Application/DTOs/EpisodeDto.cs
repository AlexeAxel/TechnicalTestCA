using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RickAndMorty.Application.DTOs
{

    public record EpisodeDto(
    int Id,
    string Name,
    string AirDate,
    string EpisodeCode,
    List<string> Characters,
    string Url,
    DateTime Created
    );

    public record PagedEpisodeDto(
        PageInfoDto Info,
        List<EpisodeDto> Results
    );

    public record PageInfoDto(
        int Count,
        int Pages,
        string? Next,
        string? Prev,
        int CurrentPage
    );

}