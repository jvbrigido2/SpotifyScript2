namespace SpotifyScript2.Models;
public class Artist
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public ICollection<Album> Albums { get; set; } = [];
    public ICollection<Track> Tracks { get; set; } = [];
}
