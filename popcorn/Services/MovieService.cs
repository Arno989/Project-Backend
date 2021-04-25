using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using popcorn.DTO;
using popcorn.Models;
using popcorn.Repositories;

namespace popcorn.Services
{
    public interface IMovieService
    {
        Task<ActorDTO> AddActor(ActorDTO actor);
        Task<MovieDTO> AddMovie(MovieDTO movie);
        Task<TorrentDTO> AddTorrent(TorrentDTO torrent);
        Task<List<ActorDTO>> GetActor(string id);
        Task<List<ActorDTO>> GetActors();
        Task<List<MovieDTO>> GetMovie(string id);
        Task<List<MovieDTO>> GetMovies();
        Task<List<TorrentDTO>> GetTorrent(string id);
    }

    public class MovieService : IMovieService
    {
        private IMovieRepository _movieRepository;
        private IActorRepository _actorRepository;
        private ITorrentRepository _torrentRepository;
        private IMapper _mapper;

        public MovieService(
            IMovieRepository movieRepository,
            IActorRepository actorRepository,
            ITorrentRepository torrentRepository,
            IMapper mapper)
        {
            _movieRepository = movieRepository;
            _actorRepository = actorRepository;
            _torrentRepository = torrentRepository;
            _mapper = mapper;
        }

        #region Actor
        public async Task<List<ActorDTO>> GetActors()
        {
            return _mapper.Map<List<ActorDTO>>(await _actorRepository.GetActors());
        }

        public async Task<List<ActorDTO>> GetActor(String id)
        {
            return _mapper.Map<List<ActorDTO>>(await _actorRepository.GetActor(id));
        }

        public async Task<ActorDTO> AddActor(ActorDTO actor)
        {
            Actor newActor = _mapper.Map<Actor>(actor);
            await _actorRepository.AddActor(newActor);
            return actor;
        }
        #endregion

        #region Movie
        public async Task<List<MovieDTO>> GetMovies()
        {
            return _mapper.Map<List<MovieDTO>>(await _movieRepository.GetMovies());
        }

        public async Task<List<MovieDTO>> GetMovie(String id)
        {
            return _mapper.Map<List<MovieDTO>>(await _movieRepository.GetMovie(id));
        }

        public async Task<MovieDTO> AddMovie(MovieDTO movie)
        {
            Movie newMovie = _mapper.Map<Movie>(movie);
            await _movieRepository.AddMovie(newMovie);
            return movie;
        }
        #endregion

        #region Torrent
        public async Task<List<TorrentDTO>> GetTorrent(String id)
        {
            return _mapper.Map<List<TorrentDTO>>(await _torrentRepository.GetTorrent(id));
        }

        public async Task<TorrentDTO> AddTorrent(TorrentDTO torrent)
        {
            Torrent newTorrent = _mapper.Map<Torrent>(torrent);
            await _torrentRepository.AddTorrent(newTorrent);
            return torrent;
        }
        #endregion

    }
}
