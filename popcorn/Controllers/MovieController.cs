using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using popcorn.DTO;
using popcorn.Models;
using popcorn.Services;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Authorization;

/* TODO

Add Api security
add relations or something with gets
GET torrent op ID geeft lege lijst
GET's on ID geen list teruggeven (like movies)

*/

namespace popcorn.Controllers
{
    // [Authorize]
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
        [Route("actors")]
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
            catch
            {
                return new StatusCodeResult(500);
            }

        }

        [HttpGet]
        [Route("actors/{id}")]
        public async Task<ActionResult<List<ActorDTO>>> GetActor(String id)
        {
            try
            {
                return await _movieService.GetActor(id);
            }
            catch
            {
                return new StatusCodeResult(500);
            }
        }

        [HttpPost]
        [Route("actors")]
        public async Task<ActionResult<ActorDTO>> AddActor(ActorDTO actor)
        {
            try
            {
                return new OkObjectResult(await _movieService.AddActor(actor));
            }
            catch
            {
                return new StatusCodeResult(500);
            }
        }
        #endregion

        #region Genre
        [HttpGet]
        [Route("genres")]
        [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any)]
        public async Task<ActionResult<List<GenreDTO>>> GetGenre()
        {
            try
            {
                List<GenreDTO> genres;
                _cache.TryGetValue<List<GenreDTO>>("genres", out genres);

                if (genres == null)
                {
                    genres = await _movieService.GetGenres();
                    _cache.Set<List<GenreDTO>>("genres", genres, DateTime.Now.AddSeconds(10));
                }
                return new OkObjectResult(genres);
            }
            catch
            {
                return new StatusCodeResult(500);
            }
            
        }

        [HttpGet]
        [Route("genres/{id}")]
        public async Task<ActionResult<List<GenreDTO>>> GetGenre(Guid id)
        {
            try
            {
                return await _movieService.GetGenre(id);
            }
            catch
            {
                return new StatusCodeResult(500);
            }
        }

        [HttpPost]
        [Route("genres")]
        public async Task<ActionResult<GenreDTO>> AddGenre(GenreDTO genre)
        {
            try
            {
                return new OkObjectResult(await _movieService.AddGenre(genre));
            }
            catch
            {
                return new StatusCodeResult(500);
            }
        }
        #endregion

        #region Movie
        [HttpGet]
        [Route("movies")]
        [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any)]
        public async Task<ActionResult<List<MovieDTO>>> GetMovies()
        {
            try
            {
                List<MovieDTO> movie;
                _cache.TryGetValue<List<MovieDTO>>("movie", out movie);

                if (movie == null)
                {
                    movie = await _movieService.GetMovies();
                    _cache.Set<List<MovieDTO>>("movie", movie, DateTime.Now.AddSeconds(10));
                }
                return new OkObjectResult(movie);
            }
            catch
            {
                return new StatusCodeResult(500);
            }
        }

        [HttpGet]
        [Route("movies/{id}")]
        public async Task<ActionResult<MovieDTO>> GetMovie(String id)
        {
            try
            {
                return new OkObjectResult(await _movieService.GetMovie(id));
            }
            catch
            {
                return new StatusCodeResult(500);
            }
        }

        [HttpPost]
        [Route("movies")]
        public async Task<ActionResult<MovieDTO>> AddMovie(MovieDTO movie)
        {
            try
            {
                return new OkObjectResult(await _movieService.AddMovie(movie));
            }
            catch
            {
                return new StatusCodeResult(500);
            }
        }
        #endregion

        #region Torrent
        [HttpGet]
        [Route("torrents")]
        [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any)]
        public async Task<ActionResult<List<TorrentDTO>>> GetTorrents()
        {
            try
            {
                List<TorrentDTO> torrent;
                _cache.TryGetValue<List<TorrentDTO>>("torrent", out torrent);

                if (torrent == null)
                {
                    torrent = await _movieService.GetTorrents();
                    _cache.Set<List<TorrentDTO>>("torrent", torrent, DateTime.Now.AddSeconds(10));
                }
                return new OkObjectResult(torrent);
            }
            catch
            {
                return new StatusCodeResult(500);
            }
        }

        [HttpGet]
        [Route("torrents/{id}")]
        public async Task<ActionResult<List<TorrentDTO>>> GetTorrents(String movieId)
        {
            try
            {
                return new OkObjectResult(await _movieService.GetTorrent(movieId));
            }
            catch
            {
                return new StatusCodeResult(500);
            }
        }

        [HttpPost]
        [Route("torrents")]
        public async Task<ActionResult<TorrentDTO>> AddTorrent(TorrentDTO torrent)
        {
            try
            {
                return new OkObjectResult(await _movieService.AddTorrent(torrent));
            }
            catch
            {
                return new StatusCodeResult(500);
            }
        }
        #endregion
        
    }
}
