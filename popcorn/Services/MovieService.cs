using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using popcorn.Models;
using popcorn.Repositories;

namespace popcorn.Services
{
    public interface IMovieService
    {
        Task<Actor> AddActor(Actor actor);
        Task<Movie> AddMovie(Movie movie);
        Task<Torrent> AddTorrent(Torrent torrent);
        Task<List<Actor>> GetActor(string id);
        Task<List<Actor>> GetActors();
        Task<List<Movie>> GetMovie(string id);
        Task<List<Movie>> GetMovies();
        Task<List<Torrent>> GetTorrent(string id);
    }

    public class MovieService : IMovieService
    {
        private IMovieRepository _movieRepository;
        private IActorRepository _actorRepository;
        private ITorrentRepository _torrentRepository;

        public MovieService(
            IMovieRepository movieRepository,
            IActorRepository actorRepository,
            ITorrentRepository torrentRepository)
        {
            _movieRepository = movieRepository;
            _actorRepository = actorRepository;
            _torrentRepository = torrentRepository;
        }

        #region Actor
        public async Task<List<Actor>> GetActors()
        {
            return await _actorRepository.GetActors();
        }

        public async Task<List<Actor>> GetActor(String id)
        {
            return await _actorRepository.GetActor(id);
        }

        public async Task<Actor> AddActor(Actor actor)
        {
            await _actorRepository.AddActor(actor);
            return actor;
        }
        #endregion

        #region Movie
        public async Task<List<Movie>> GetMovies()
        {
            return await _movieRepository.GetMovies();
        }

        public async Task<List<Movie>> GetMovie(String id)
        {
            return await _movieRepository.GetMovie(id);
        }

        public async Task<Movie> AddMovie(Movie movie)
        {
            await _movieRepository.AddMovie(movie);
            return movie;
        }
        #endregion

        #region Torrent
        public async Task<List<Torrent>> GetTorrent(String id)
        {
            return await _torrentRepository.GetTorrent(id);
        }

        public async Task<Torrent> AddTorrent(Torrent torrent)
        {
            await _torrentRepository.AddTorrent(torrent);
            return torrent;
        }
        #endregion

    }
}
