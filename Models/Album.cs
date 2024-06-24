namespace SpotifyScript2.Models;
public class Album
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public ICollection<Artist> Artists { get; set; } = [];
    public ICollection<Track> Tracks { get; set; } = [];
   
}
