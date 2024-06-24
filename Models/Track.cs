namespace SpotifyScript2.Models;
public class Track
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string AlbumId { get; set; } = null!;
    public Album Album { get; set; } = null!;
    public ICollection<Artist> Artists { get; set; } = [];

}

   
