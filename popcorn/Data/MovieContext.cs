using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using popcorn.Configuration;
using popcorn.Models;

namespace popcorn.Data
{
    public interface IMovieContext
    {
        DbSet<Actor> Actors { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<Movie> Movies { get; set; }
        DbSet<MovieActor> MovieActors { get; set; }
        DbSet<MovieGenre> MovieGenres { get; set; }
        DbSet<Torrent> Torrents { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }

    public class MovieContext : DbContext, IMovieContext
    {
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<Torrent> Torrents { get; set; }

        private ConnectionStrings _connectionStrings;

        public MovieContext(DbContextOptions<MovieContext> options, IOptions<ConnectionStrings> connectionStrings)
        {
            _connectionStrings = connectionStrings.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddDebug()));
            options.UseSqlServer(_connectionStrings.SQL);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieGenre>()
                .HasKey(mg => new { mg.IMDBMovieId, mg.GenreId });
            modelBuilder.Entity<MovieGenre>()
                .HasOne(mg => mg.Movie)
                .WithMany(m => m.MovieGenres)
                .HasForeignKey(mg => mg.IMDBMovieId);
            modelBuilder.Entity<MovieGenre>()
                .HasOne(mg => mg.Genre)
                .WithMany(g => g.MovieGenres)
                .HasForeignKey(mg => mg.GenreId);


            modelBuilder.Entity<MovieActor>()
                .HasKey(ma => new { ma.IMDBMovieId, ma.IMDBActorId });
            modelBuilder.Entity<MovieActor>()
                .HasOne(ma => ma.Movie)
                .WithMany(m => m.MovieActors)
                .HasForeignKey(ma => ma.IMDBMovieId);
            modelBuilder.Entity<MovieActor>()
                .HasOne(ma => ma.Actor)
                .WithMany(a => a.MovieActors)
                .HasForeignKey(ma => ma.IMDBActorId);


            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Torrents)
                .WithOne(t => t.Movie)
                .HasForeignKey(t => t.IMDBMovieId);


            #region Actor
            modelBuilder.Entity<Actor>().HasData(new Actor()
            {
                IMDBActorId = "nm0000151",
                Name = "Morgan Freeman",
                Born = new DateTime(1937, 6, 1)
            });

            modelBuilder.Entity<Actor>().HasData(new Actor()
            {
                IMDBActorId = "nm0000209",
                Name = "Tim Robbins",
                Born = new DateTime(1958, 10, 16)
            });

            modelBuilder.Entity<Actor>().HasData(new Actor()
            {
                IMDBActorId = "nm0424060",
                Name = "Scarlett Johansson",
                Born = new DateTime(1984, 11, 22)
            });
            #endregion

            #region Movie
            Movie movie1 = new Movie()
            {
                IMDBMovieId = "tt0111161",
                Name = "The Shawshank Redemption",
                Runtime = 142,
                ReleaseDate = new DateTime(1994, 10, 14),
                Synopsis = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                Rating = 9.3,

            };

            Movie movie2 = new Movie()
            {
                IMDBMovieId = "tt2872732",
                Name = "Lucy",
                Runtime = 89,
                ReleaseDate = new DateTime(2014, 7, 25),
                Synopsis = "A woman, accidentally caught in a dark deal, turns the tables on her captors and transforms into a merciless warrior evolved beyond human logic.",
                Rating = 6.4
            };

            modelBuilder.Entity<Movie>().HasData(movie1, movie2);
            #endregion

            #region Torrent
            modelBuilder.Entity<Torrent>().HasData(new Torrent()
            {
                TorrentId = Guid.NewGuid(),
                // Movie = movie1,
                IMDBMovieId = "tt0111161",
                MagnetLink = "https://yts.mx/torrent/download/E0D00667650ABA9EE05AACBBBD8B55EA8A51F534",
                Quality = "1080p",
                Seeds = 25,
                Peers = 36,
                FileSize = "1.4Gb"
            });

            modelBuilder.Entity<Torrent>().HasData(new Torrent()
            {
                TorrentId = Guid.NewGuid(),
                // Movie = movie2,
                IMDBMovieId = "tt2872732",
                MagnetLink = "https://yts.mx/torrent/download/D421A1EFA2A8231F4FC1EABC69C5B64F8E823F71",
                Quality = "1080p",
                Seeds = 154,
                Peers = 568,
                FileSize = "1.8Gb"
            });

            modelBuilder.Entity<Torrent>().HasData(new Torrent()
            {
                TorrentId = Guid.NewGuid(),
                // Movie = movie2,
                IMDBMovieId = "tt2872732",
                MagnetLink = "https://yts.mx/torrent/download/EA20559FAD8179E5468EF5B7752553D8A0D62CDE",
                Quality = "720p",
                Seeds = 54,
                Peers = 23,
                FileSize = "785Mb"
            });
            #endregion

            #region Genre
            Guid tempGuidDrama = Guid.NewGuid();
            Guid tempGuidAction = Guid.NewGuid();
            Guid tempGuidSciFi = Guid.NewGuid();
            Guid tempGuidThriller = Guid.NewGuid();

            modelBuilder.Entity<Genre>().HasData(new Genre()
            {
                GenreId = tempGuidDrama,
                Name = "Drama",
            });

            modelBuilder.Entity<Genre>().HasData(new Genre()
            {
                GenreId = tempGuidAction,
                Name = "Action",
            });

            modelBuilder.Entity<Genre>().HasData(new Genre()
            {
                GenreId = tempGuidSciFi,
                Name = "Sci-Fi",
            });

            modelBuilder.Entity<Genre>().HasData(new Genre()
            {
                GenreId = tempGuidThriller,
                Name = "Thriller",
            });
            #endregion

            #region Many to Many
            modelBuilder.Entity<MovieGenre>().HasData(new MovieGenre()
            {
                IMDBMovieId = "tt0111161",
                GenreId = tempGuidDrama,
            });

            modelBuilder.Entity<MovieGenre>().HasData(new MovieGenre()
            {
                IMDBMovieId = "tt2872732",
                GenreId = tempGuidAction,
            });

            modelBuilder.Entity<MovieGenre>().HasData(new MovieGenre()
            {
                IMDBMovieId = "tt2872732",
                GenreId = tempGuidSciFi,
            });

            modelBuilder.Entity<MovieGenre>().HasData(new MovieGenre()
            {
                IMDBMovieId = "tt2872732",
                GenreId = tempGuidThriller,
            });


            modelBuilder.Entity<MovieActor>().HasData(new MovieActor()
            {
                IMDBMovieId = "tt2872732",
                IMDBActorId = "nm0424060",
            });

            modelBuilder.Entity<MovieActor>().HasData(new MovieActor()
            {
                IMDBMovieId = "tt2872732",
                IMDBActorId = "nm0000151",
            });

            modelBuilder.Entity<MovieActor>().HasData(new MovieActor()
            {
                IMDBMovieId = "tt0111161",
                IMDBActorId = "nm0000151",
            });

            modelBuilder.Entity<MovieActor>().HasData(new MovieActor()
            {
                IMDBMovieId = "tt0111161",
                IMDBActorId = "nm0000209",
            });
            #endregion
        }
    }
}
