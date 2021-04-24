using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using popcorn.Configuration;
using popcorn.Models;

namespace popcorn.Data
{
    public interface IMovieContext
    {
        DbSet<Movie> Movies { get; set; }
        DbSet<Actor> Actors { get; set; }
        DbSet<Torrent> Torrents { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }

    public class MovieContext : DbContext, IMovieContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Torrent> Torrents { get; set; }

        private ConnectionStrings _connectionStrings;

        public MovieContext(DbContextOptions<MovieContext> options, IOptions<ConnectionStrings> connectionStrings)
        {
            _connectionStrings = connectionStrings.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_connectionStrings.SQL);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<SneakerBrand>().HasData(new SneakerBrand() { BrandId = Guid.NewGuid(), Name = "ASICS" });
            // modelBuilder.Entity<SneakerBrand>().HasData(new SneakerBrand() { BrandId = Guid.NewGuid(), Name = "CONVERSE" });
            // modelBuilder.Entity<SneakerBrand>().HasData(new SneakerBrand() { BrandId = Guid.NewGuid(), Name = "JORDAN" });
            // modelBuilder.Entity<SneakerBrand>().HasData(new SneakerBrand() { BrandId = Guid.NewGuid(), Name = "PUMA" });


            // modelBuilder.Entity<SneakerOccasion>().HasData(new SneakerOccasion() { OccasionId = Guid.NewGuid(), Name = "Sports" });
            // modelBuilder.Entity<SneakerOccasion>().HasData(new SneakerOccasion() { OccasionId = Guid.NewGuid(), Name = "Casual" });
            // modelBuilder.Entity<SneakerOccasion>().HasData(new SneakerOccasion() { OccasionId = Guid.NewGuid(), Name = "Skate" });
            // modelBuilder.Entity<SneakerOccasion>().HasData(new SneakerOccasion() { OccasionId = Guid.NewGuid(), Name = "Diner" });
        }
    }
}
