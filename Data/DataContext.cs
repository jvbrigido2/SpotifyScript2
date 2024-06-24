
using Microsoft.EntityFrameworkCore;
using SpotifyScript2.Models;

namespace SpotifyScript2.Data;
public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=spotifydb;Username=postgres;Password=8118");
        }
    }
   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Album>()
            .HasMany(a => a.Artists)
            .WithMany(a => a.Albums)
            .UsingEntity(j => j.ToTable("AlbumArtists"));

        modelBuilder.Entity<Track>()
            .HasMany(t => t.Artists)
            .WithMany(a => a.Tracks)
            .UsingEntity(j => j.ToTable("TrackArtists"));

        modelBuilder.Entity<Track>()
            .HasOne(t => t.Album)
            .WithMany(a => a.Tracks)
            .HasForeignKey(t => t.AlbumId);

        
        modelBuilder.Entity<AudioBook>()
            .HasMany(ab => ab.Chapters)
            .WithOne(ch => ch.AudioBook)
            .HasForeignKey(ch => ch.AudioBookId);

        
        modelBuilder.Entity<Episode>()
            .HasOne(ep => ep.Show)
            .WithMany(s => s.Episodes)
            .HasForeignKey(ep => ep.ShowId);

    }

    public DbSet<Track> Tracks { get; set; }
    public DbSet<Album> Albums { get; set; }
    public DbSet<Artist> Artists { get; set; }
    public DbSet<AudioBook> AudioBooks { get; set; }
    public DbSet<Categories> Categories { get; set; }
    public DbSet<Chapter> Chapters { get; set; }
    public DbSet<Episode> Episodes { get; set;}
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Market> Markets { get; set; }
    public DbSet<Playlist> Playlists { get; set; }
    public DbSet<Show> Shows { get; set; }
    public DbSet<User> Users { get; set; }

}
