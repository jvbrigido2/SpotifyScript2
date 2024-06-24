namespace SpotifyScript2.Models;
public class Chapter
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public AudioBook AudioBook { get; set; } = null!;
    public string AudioBookId { get; set; } = null!;

}
