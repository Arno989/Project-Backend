using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using popcorn.Data;
using popcorn.Models;

namespace popcorn.Repositories
{
    public interface ITorrentRepository
    {
        Task<Torrent> AddTorrent(Torrent torrent);
        Task<List<Torrent>> GetTorrent(String id);
    }

    public class TorrentRepository : ITorrentRepository
    {
        private IMovieContext _context;
        public TorrentRepository(IMovieContext context)
        {
            _context = context;
        }

        public async Task<List<Torrent>> GetTorrent(String id)
        {
            return await _context.Torrents.Include(r => r.IMDBMovieId == id).ToListAsync();
        }

        public async Task<Torrent> AddTorrent(Torrent torrent)
        {
            await _context.Torrents.AddAsync(torrent);
            await _context.SaveChangesAsync();
            return torrent;
        }
    }
}
