using RickAndMorty.API.Middleware;
using RickAndMorty.Application.Interfaces;
using RickAndMorty.Application.Services;
using RickAndMorty.Domain.Interfaces;
using RickAndMorty.Infrastructure.Configuration;
using RickAndMorty.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<RickAndMortyApiSettings>(
    builder.Configuration.GetSection("RickAndMortyApi"));

var apiSettings = builder.Configuration.GetSection("RickAndMortyApi").Get<RickAndMortyApiSettings>();

builder.Services.AddHttpClient<IEpisodeRepository, EpisodeRepository>(client =>
{
    client.BaseAddress = new Uri(apiSettings!.BaseUrl);
    client.Timeout = TimeSpan.FromSeconds(apiSettings.TimeoutSeconds);
});

builder.Services.AddScoped<IEpisodeService, EpisodeService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins(builder.Configuration["Cors:AllowedOrigins"]!.Split(","))
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseCors("AllowAngularApp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
