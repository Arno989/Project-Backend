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

namespace popcorn.Controllers
{
    // https://manage.auth0.com/dashboard/eu/dev-0q9d0sfz/apis/608d79dff9b1e30045d92869/test

    [Authorize]
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
        [AllowAnonymous]
        [Route("actors")]
        [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any)]
        public async Task<ActionResult<List<ExtendedActorDTO>>> GetActor()
        {
            try
            {
                List<ExtendedActorDTO> actors;
                _cache.TryGetValue<List<ExtendedActorDTO>>("actors", out actors);

                if (actors == null)
                {
                    actors = await _movieService.GetActors();
                    _cache.Set<List<ExtendedActorDTO>>("actors", actors, DateTime.Now.AddSeconds(10));
                }
                return new OkObjectResult(actors);
            }
            catch
            {
                return new StatusCodeResult(500);
            }

        }

        [HttpGet]
        [AllowAnonymous]
        [Route("actors/{id}")]
        public async Task<ActionResult<ExtendedActorDTO>> GetActor(String id)
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
        [AllowAnonymous]
        [Route("actors")]
        public async Task<ActionResult<ExtendedActorDTO>> AddActor(ExtendedActorDTO actor)
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
        [AllowAnonymous]
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
        [AllowAnonymous]
        [Route("genres/{id}")]
        public async Task<ActionResult<GenreDTO>> GetGenre(Guid id)
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
        [AllowAnonymous]
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
        [AllowAnonymous]
        [Route("movies")]
        [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any)]
        public async Task<ActionResult<List<ExtendedMovieDTO>>> GetMovies()
        {
            try
            {
                List<ExtendedMovieDTO> movie;
                _cache.TryGetValue<List<ExtendedMovieDTO>>("movie", out movie);

                if (movie == null)
                {
                    movie = await _movieService.GetMovies();
                    _cache.Set<List<ExtendedMovieDTO>>("movie", movie, DateTime.Now.AddSeconds(10));
                }
                return new OkObjectResult(movie);
            }
            catch
            {
                return new StatusCodeResult(500);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("movies/{id}")]
        public async Task<ActionResult<ExtendedMovieDTO>> GetMovie(String id)
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
        [AllowAnonymous]
        [Route("movies")]
        public async Task<ActionResult<ExtendedMovieDTO>> AddMovie(ExtendedMovieDTO movie)
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
        [AllowAnonymous] // yeet dis
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
        [AllowAnonymous]
        [Route("torrents/{id}")]
        public async Task<ActionResult<List<TorrentDTO>>> GetTorrents(String id)
        {
            try
            {
                return new OkObjectResult(await _movieService.GetTorrent(id));
            }
            catch
            {
                return new StatusCodeResult(500);
            }
        }

        [HttpPost]
        [AllowAnonymous] // yeet dis
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
