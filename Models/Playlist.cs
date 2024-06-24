namespace SpotifyScript2.Models;
public class Playlist
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public ICollection<Track> Tracks { get; set; } = [];
}
