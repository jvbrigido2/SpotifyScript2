
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SpotifyScript2.Data;
using SpotifyScript2.Models;
using SpotifyScript2.Service;
using System.Runtime.CompilerServices;
using static System.Net.WebRequestMethods;

public class Program
{
    static async Task Main(string[] args)
    {
        var serviceProvider = ConfigureServices();
        var clientId = "b6eca7ff99dc487685572beb88ee5c4b";
        var clientSecret = "19558a648ff84e6a8b7bc51d2155edb7";

        var authService = new SpotifyAuthService(clientId, clientSecret);
        var accessToken = await authService.AccessToken();
        var dataContext = serviceProvider.GetRequiredService<DataContext>();

        var query = "remaster%2520track%3ADoxy%2520artist%3AMiles%2520Davis";
        var type = "track,album,artist,playlist,show,episode,audiobook";
        var limit = 50;

        var http = new HttpClient();

        var url = $"https://api.spotify.com/v1/search?q={query}&type={type}&limit={limit}";
        http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
        var response = await http.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();

        var searchResult = JsonConvert.DeserializeObject<JObject>(content);

        

        // Albums
        foreach (var albumJson in searchResult["albums"]["items"])
        {
            var albumId = albumJson["id"].ToString();
            var album = await dataContext.Albums.FindAsync(albumId);
            if (album == null)
            {
                album = new Album
                {
                    Id = albumId,
                    Name = albumJson["name"].ToString()
                };
                dataContext.Albums.Add(album);
            }

            var artists = new List<Artist>();
            foreach (var artistJson in albumJson["artists"])
            {
                var artistId = artistJson["id"].ToString();
                var artist = await dataContext.Artists.FindAsync(artistId);
                if (artist == null)
                {
                    artist = new Artist
                    {
                        Id = artistId,
                        Name = artistJson["name"].ToString()
                    };
                    dataContext.Artists.Add(artist);
                }
                artists.Add(artist);
            }

            album.Artists = artists;
        }

        // Tracks
        foreach (var trackJson in searchResult["tracks"]["items"])
        {
            var albumId = trackJson["album"]["id"].ToString();
            var album = await dataContext.Albums.FindAsync(albumId);
            if (album == null)
            {
                album = new Album
                {
                    Id = albumId,
                    Name = trackJson["album"]["name"].ToString()
                };

                var albumArtists = new List<Artist>();
                foreach (var artistJson in trackJson["album"]["artists"])
                {
                    var artistId = artistJson["id"].ToString();
                    var artist = await dataContext.Artists.FindAsync(artistId);
                    if (artist == null)
                    {
                        artist = new Artist
                        {
                            Id = artistId,
                            Name = artistJson["name"].ToString()
                        };
                        dataContext.Artists.Add(artist);
                    }
                    albumArtists.Add(artist);
                }
                album.Artists = albumArtists;
                dataContext.Albums.Add(album);
            }

            var track = new Track
            {
                Id = trackJson["id"].ToString(),
                Name = trackJson["name"].ToString(),
                Album = album
            };

            var trackArtists = new List<Artist>();
            foreach (var artistJson in trackJson["artists"])
            {
                var artistId = artistJson["id"].ToString();
                var artist = await dataContext.Artists.FindAsync(artistId);
                if (artist == null)
                {
                    artist = new Artist
                    {
                        Id = artistId,
                        Name = artistJson["name"].ToString()
                    };
                    dataContext.Artists.Add(artist);
                }
                trackArtists.Add(artist);
            }
            track.Artists = trackArtists;

            dataContext.Tracks.Add(track);
        }
        // Genres
        var genresUrl = "https://api.spotify.com/v1/recommendations/available-genre-seeds";
        var genresResponse = await http.GetAsync(genresUrl);
        genresResponse.EnsureSuccessStatusCode();

        var genresContent = await genresResponse.Content.ReadAsStringAsync();
        var genresResult = JsonConvert.DeserializeObject<JObject>(genresContent);

        foreach (var genreName in genresResult["genres"])
        {
            var genre = new Genre
            {
                Name = genreName.ToString()
            };
            dataContext.Genres.Add(genre);
        }
        // Categories
        var categoriesUrl = $"https://api.spotify.com/v1/browse/categories?limit={limit}";
        var categoriesResponse = await http.GetAsync(categoriesUrl);
        categoriesResponse.EnsureSuccessStatusCode();

        var categoriesContent = await categoriesResponse.Content.ReadAsStringAsync();
        var categoriesResult = JsonConvert.DeserializeObject<JObject>(categoriesContent);

        foreach (var categoryJson in categoriesResult["categories"]["items"])
        {
            var category = new Categories
            {
                Id = categoryJson["id"].ToString(),
                Name = categoryJson["name"].ToString(),
            };
            dataContext.Categories.Add(category);
        }

        // Markets
        var marketUrl = "https://api.spotify.com/v1/markets";
        var marketResponse = await http.GetAsync(marketUrl);
        marketResponse.EnsureSuccessStatusCode();

        var marketContent = await marketResponse.Content.ReadAsStringAsync();
        var marketResult = JsonConvert.DeserializeObject<JObject>(marketContent);

        foreach (var marketName in marketResult["markets"])
        {
            var market = new Market
            {
                Name = marketName.ToString()
            };
            dataContext.Markets.Add(market);
        }

        // User
        var userId = "jvbrigido";
        var userUrl = $"https://api.spotify.com/v1/users/{userId}";
        var userResponse = await http.GetAsync(userUrl);
        userResponse.EnsureSuccessStatusCode();

        var userContent = await userResponse.Content.ReadAsStringAsync();
        var userResult = JsonConvert.DeserializeObject<JObject>(userContent);

        var user = new User
        {
            DisplayName = userResult["display_name"].ToString(),
            Id = userResult["id"].ToString(),
            Uri = userResult["uri"].ToString()
        };
        dataContext.Users.Add(user);


        await dataContext.SaveChangesAsync();
        Console.WriteLine("Dados foram salvos com sucesso!");

        Console.ReadKey();

    }

    private static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddDbContext<DataContext>();

        
        var serviceProvider = services.BuildServiceProvider();
        return serviceProvider;
    }
}