namespace SpotifyScript2.Models;
public class Episode
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public Show Show { get; set; } = null!; 
    public string ShowId { get; set; } = null!;


}
