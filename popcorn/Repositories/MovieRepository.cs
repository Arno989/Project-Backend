using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using popcorn.Data;
using popcorn.Models;

namespace popcorn.Repositories
{
    public interface IMovieRepository
    {
        Task<Movie> AddMovie(Movie movie);
        Task<List<Movie>> GetMovie(String id);
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

        public async Task<List<Movie>> GetMovie(String id)
        {
            return await _context.Movies.Include(r => r.IMDBMovieId == id).ToListAsync();
        }

        public async Task<Movie> AddMovie(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
            return movie;
        }
    }
}
