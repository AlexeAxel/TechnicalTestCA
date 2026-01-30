using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RickAndMorty.Domain.Entities
{
    public class Episode
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string AirDate { get; set; } = string.Empty;
        public string EpisodeCode { get; set; } = string.Empty;
        public List<string> Characters { get; set; } = new();
        public string Url { get; set; } = string.Empty;
        public DateTime Created { get; set; }
    }
}