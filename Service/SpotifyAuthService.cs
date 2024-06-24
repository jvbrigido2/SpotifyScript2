using Newtonsoft.Json;

namespace SpotifyScript2.Service;
public class SpotifyAuthService
{
    private readonly string _clientId;
    private readonly string _clientSecret;
    private string? _accessToken;

    public SpotifyAuthService(string clientId, string clientSecret)
    {
        _clientId = clientId;
        _clientSecret = clientSecret;
    }
    public async Task<string?> AccessToken()
    {
        var http = new HttpClient();
        var tokenRequest = new Dictionary<string, string>
        {
            {"grant_type", "client_credentials"},
            {"client_id", _clientId},
            {"client_secret", _clientSecret}
        };
        var tokenResponse = await http.PostAsync("https://accounts.spotify.com/api/token", new FormUrlEncodedContent(tokenRequest));
        var tokenContent = await tokenResponse.Content.ReadAsStringAsync();
        var tokenObject = JsonConvert.DeserializeObject<dynamic>(tokenContent);

        _accessToken = tokenObject?.access_token;

        return _accessToken;

    }
    
    
}
