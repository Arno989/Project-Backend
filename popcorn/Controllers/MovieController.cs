using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using popcorn.DTO;
using popcorn.Models;
using popcorn.Services;
using Microsoft.Extensions.Caching.Memory;

/* TODO

Add caching to all GET endpoints
Fix n:n relations
Add testing
Add Api security
Add logging?

*/

namespace popcorn.Controllers
{
    [ApiController]
    [Route("api")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMemoryCache _cache;
        private readonly ILogger<MovieController> _logger;

        
        public MovieController(ILogger<MovieController> logger, IMovieService movieService, IMemoryCache cache)
        {
            _logger = logger;
            _movieService = movieService;
            _cache = cache;
        }

        #region Actor
        [HttpGet]
        [Route("/actor")]
        [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any)]
        public async Task<ActionResult<List<ActorDTO>>> GetActor()
        {
            try
            {
                List<ActorDTO> actors;
                _cache.TryGetValue<List<ActorDTO>>("actors", out actors);

                if (actors == null)
                {
                    actors = await _movieService.GetActors();
                    _cache.Set<List<ActorDTO>>("actors", actors, DateTime.Now.AddSeconds(10));
                }
                return new OkObjectResult(actors);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
                throw ex;
            }
            
        }

        [HttpGet]
        [Route("/actor/{id}")]
        public async Task<ActionResult<List<ActorDTO>>> GetActor(String id)
        {
            try
            {
                return await _movieService.GetActor(id);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
                throw ex;
            }
        }

        [HttpPost]
        [Route("/actor")]
        public async Task<ActionResult<ActorDTO>> AddActor(ActorDTO actor)
        {
            try
            {
                return new OkObjectResult(await _movieService.AddActor(actor));
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
                throw ex;
            }
        }
        #endregion

        #region Movie
        [HttpGet]
        [Route("/movies")]
        public async Task<ActionResult<List<MovieDTO>>> GetMovies()
        {
            try
            {
                return new OkObjectResult(await _movieService.GetMovies());
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
                throw ex;
            }
        }

        [HttpGet]
        [Route("/movie/{id}")]
        public async Task<ActionResult<List<MovieDTO>>> GetMovies(String id)
        {
            try
            {
                return new OkObjectResult(await _movieService.GetMovie(id));
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
                throw ex;
            }
        }

        [HttpPost]
        [Route("/movie")]
        public async Task<ActionResult<MovieDTO>> AddMovie(MovieDTO movie)
        {
            try
            {
                return new OkObjectResult(await _movieService.AddMovie(movie));
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
                throw ex;
            }
        }
        #endregion

        #region Torrent
        [HttpGet]
        [Route("/torrent/{id}")]
        public async Task<ActionResult<List<TorrentDTO>>> GetTorrents(String id)
        {
            try
            {
                return new OkObjectResult(await _movieService.GetTorrent(id));
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
                throw ex;
            }
        }

        [HttpPost]
        [Route("/torrent")]
        public async Task<ActionResult<TorrentDTO>> AddTorrent(TorrentDTO torrent)
        {
            try
            {
                return new OkObjectResult(await _movieService.AddTorrent(torrent));
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
                throw ex;
            }
        }
        #endregion
        
    }
}
