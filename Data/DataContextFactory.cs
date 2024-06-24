using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace SpotifyScript2.Data;
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Database=spotifydb;Username=postgres;Password=8118")
             .EnableSensitiveDataLogging();

            return new DataContext(optionsBuilder.Options);
        }
    }

