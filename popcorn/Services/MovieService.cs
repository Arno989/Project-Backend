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
        Task<GenreDTO> AddGenre(GenreDTO Genre);
        Task<MovieDTO> AddMovie(MovieDTO movie);
        Task<TorrentDTO> AddTorrent(TorrentDTO torrent);
        Task<List<ActorDTO>> GetActor(string id);
        Task<List<ActorDTO>> GetActors();
        Task<List<GenreDTO>> GetGenre(Guid id);
        Task<List<GenreDTO>> GetGenres();
        Task<MovieDTO> GetMovie(string id);
        Task<List<MovieDTO>> GetMovies();
        Task<List<TorrentDTO>> GetTorrent(string movieId);
        Task<List<TorrentDTO>> GetTorrents();
    }

    public class MovieService : IMovieService
    {
        private IActorRepository _actorRepository;
        private IGenreRepository _genreRepository;
        private IMovieRepository _movieRepository;
        private ITorrentRepository _torrentRepository;
        private IMapper _mapper;

        public MovieService(
            IActorRepository actorRepository,
            IGenreRepository genreRepository,
            IMovieRepository movieRepository,
            ITorrentRepository torrentRepository,
            IMapper mapper)
        {
            _actorRepository = actorRepository;
            _genreRepository = genreRepository;
            _movieRepository = movieRepository;
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

        #region Genre
        public async Task<List<GenreDTO>> GetGenres()
        {
            return _mapper.Map<List<GenreDTO>>(await _genreRepository.GetGenres());
        }

        public async Task<List<GenreDTO>> GetGenre(Guid id)
        {
            return _mapper.Map<List<GenreDTO>>(await _genreRepository.GetGenre(id));
        }

        public async Task<GenreDTO> AddGenre(GenreDTO Genre)
        {
            Genre newGenre = _mapper.Map<Genre>(Genre);
            await _genreRepository.AddGenre(newGenre);
            return Genre;
        }
        #endregion

        #region Movie
        public async Task<List<MovieDTO>> GetMovies()
        {
            return _mapper.Map<List<MovieDTO>>(await _movieRepository.GetMovies());
        }

        public async Task<MovieDTO> GetMovie(String id)
        {
            return _mapper.Map<MovieDTO>(await _movieRepository.GetMovie(id));
        }

        public async Task<MovieDTO> AddMovie(MovieDTO movie)
        {
            Movie newMovie = _mapper.Map<Movie>(movie);
            await _movieRepository.AddMovie(newMovie);
            return movie;
        }
        #endregion

        #region Torrent
        public async Task<List<TorrentDTO>> GetTorrents()
        {
            return _mapper.Map<List<TorrentDTO>>(await _torrentRepository.GetTorrents());
        }

        public async Task<List<TorrentDTO>> GetTorrent(String movieId)
        {
            return _mapper.Map<List<TorrentDTO>>(await _torrentRepository.GetTorrent(movieId));
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
