using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using popcorn.Models;
using popcorn.Services;
using Microsoft.Extensions.Caching.Memory;

namespace popcorn.Controllers
{

    [ApiController]
    [Route("api")]
    public class MovieController : ControllerBase
    {
        private IMovieService _movieService;
        private IMemoryCache _cache;
        public MovieController(IMovieService movieService, IMemoryCache cache)
        {
            _movieService = movieService;
            _cache = cache;
        }

        #region Actor
        [HttpGet]
        [Route("/actor")]
        [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any)]
        public async Task<List<Actor>> GetActor()
        {
            List<Actor> actors;
            _cache.TryGetValue<List<Actor>>("actors", out actors);

            if (actors == null)
            {
                actors = await _movieService.GetActors();
                _cache.Set<List<Actor>>("actors", actors, DateTime.Now.AddSeconds(10));
            }
            return actors;
        }

        [HttpGet]
        [Route("/actor/{id}")]
        public async Task<List<Actor>> GetActor(String id)
        {
            return await _movieService.GetActor(id);
        }

        [HttpPost]
        [Route("/actor")]
        public async Task<ActionResult<Actor>> AddActor(Actor actor)
        {
            try
            {
                return await _movieService.AddActor(actor);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }
        #endregion

        #region Movie
        [HttpGet]
        [Route("/movies")]
        public async Task<List<Movie>> GetMovies()
        {
            return await _movieService.GetMovies();
        }

        [HttpGet]
        [Route("/movie/{id}")]
        public async Task<List<Movie>> GetMovies(String id)
        {
            return await _movieService.GetMovie(id);
        }

        [HttpPost]
        [Route("/movie")]
        public async Task<ActionResult<Movie>> AddMovie(Movie movie)
        {
            try
            {
                return await _movieService.AddMovie(movie);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }
        #endregion

        #region Torrent
        [HttpGet]
        [Route("/torrent/{id}")]
        public async Task<List<Torrent>> GetTorrents(String id)
        {
            return await _movieService.GetTorrent(id);
        }

        [HttpPost]
        [Route("/torrent")]
        public async Task<ActionResult<Torrent>> AddTorrent(Torrent torrent)
        {
            try
            {
                return await _movieService.AddTorrent(torrent);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }
        #endregion
        
    }
}
