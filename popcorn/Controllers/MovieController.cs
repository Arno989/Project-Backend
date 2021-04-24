using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using popcorn.Models;
using popcorn.Services;

namespace popcorn.Controllers
{
    public class MovieController : ControllerBase
    {
        private IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        #region Actor
        [HttpGet]
        [Route("/actor")]
        public async Task<List<Actor>> GetActor()
        {
            return await _movieService.GetActors();
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
