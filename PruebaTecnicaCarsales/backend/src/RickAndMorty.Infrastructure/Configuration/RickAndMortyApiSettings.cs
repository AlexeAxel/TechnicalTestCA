namespace RickAndMorty.Infrastructure.Configuration
{

    public class RickAndMortyApiSettings
    {
        public string BaseUrl { get; set; } = string.Empty;
        public int TimeoutSeconds { get; set; } = 30;
    }
}