using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using popcorn.Data;
using popcorn.Models;

namespace popcorn.Repositories
{
    public interface IActorRepository
    {
        Task<Actor> AddActor(Actor actor);
        Task<List<Actor>> GetActor(String id);
        Task<List<Actor>> GetActors();
    }

    public class ActorRepository : IActorRepository
    {
        private IMovieContext _context;
        public ActorRepository(IMovieContext context)
        {
            _context = context;
        }

        public async Task<List<Actor>> GetActors()
        {
            return await _context.Actors.ToListAsync();
        }

        public async Task<List<Actor>> GetActor(String id)
        {
            return await _context.Actors.Where(r => r.IMDBActorId == id).ToListAsync();
        }

        public async Task<Actor> AddActor(Actor actor)
        {
            await _context.Actors.AddAsync(actor);
            await _context.SaveChangesAsync();
            return actor;
        }
    }
}
