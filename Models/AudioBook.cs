namespace SpotifyScript2.Models;
public class AudioBook
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public ICollection<Chapter> Chapters { get; set; } = [];

}
