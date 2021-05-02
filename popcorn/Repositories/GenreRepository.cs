using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using popcorn.Data;
using popcorn.Models;

namespace popcorn.Repositories
{
    public interface IGenreRepository
    {
        Task<Genre> AddGenre(Genre genre);
        Task<Genre> GetGenre(Guid id);
        Task<List<Genre>> GetGenres();
    }

    public class GenreRepository : IGenreRepository
    {
        private IMovieContext _context;
        public GenreRepository(IMovieContext context)
        {
            _context = context;
        }

        public async Task<List<Genre>> GetGenres()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task<Genre> GetGenre(Guid id)
        {
            return await _context.Genres.Where(r => r.GenreId == id).SingleOrDefaultAsync();
        }

        public async Task<Genre> AddGenre(Genre genre)
        {
            await _context.Genres.AddAsync(genre);
            await _context.SaveChangesAsync();
            return genre;
        }
    }
}
