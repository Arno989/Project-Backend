using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using popcorn.Data;
using popcorn.Models;

namespace popcorn.Repositories
{
    public interface IMovieRepository
    {
        Task<Movie> AddMovie(Movie movie);
        Task<Movie> GetMovie(string id);
        Task<List<Movie>> GetMovies();
    }

    public class MovieRepository : IMovieRepository
    {
        private IMovieContext _context;
        public MovieRepository(IMovieContext context)
        {
            _context = context;
        }

        public async Task<List<Movie>> GetMovies()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie> GetMovie(String id)
        {
            Movie movie =  await _context.Movies.Where(r => r.IMDBMovieId == id)
            .Include(r => r.Torrents)
            .Include(r => r.Actors)
            .Include(r => r.Genres)
            .SingleOrDefaultAsync();
            return movie;
        }

        public async Task<Movie> AddMovie(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
            return movie;
        }
    }
}
