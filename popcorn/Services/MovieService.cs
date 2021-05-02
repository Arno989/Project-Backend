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
        Task<ExtendedActorDTO> AddActor(ExtendedActorDTO actor);
        Task<GenreDTO> AddGenre(GenreDTO Genre);
        Task<ExtendedMovieDTO> AddMovie(ExtendedMovieDTO movie);
        Task<TorrentDTO> AddTorrent(TorrentDTO torrent);
        Task<ExtendedActorDTO> GetActor(string id);
        Task<List<ExtendedActorDTO>> GetActors();
        Task<GenreDTO> GetGenre(Guid id);
        Task<List<GenreDTO>> GetGenres();
        Task<ExtendedMovieDTO> GetMovie(string id);
        Task<List<ExtendedMovieDTO>> GetMovies();
        Task<List<TorrentDTO>> GetTorrent(string id);
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
        public async Task<List<ExtendedActorDTO>> GetActors()
        {
            return _mapper.Map<List<ExtendedActorDTO>>(await _actorRepository.GetActors());
        }

        public async Task<ExtendedActorDTO> GetActor(String id)
        {
            return _mapper.Map<ExtendedActorDTO>(await _actorRepository.GetActor(id));
        }

        public async Task<ExtendedActorDTO> AddActor(ExtendedActorDTO actor)
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

        public async Task<GenreDTO> GetGenre(Guid id)
        {
            return _mapper.Map<GenreDTO>(await _genreRepository.GetGenre(id));
        }

        public async Task<GenreDTO> AddGenre(GenreDTO Genre)
        {
            Genre newGenre = _mapper.Map<Genre>(Genre);
            await _genreRepository.AddGenre(newGenre);
            return Genre;
        }
        #endregion

        #region Movie
        public async Task<List<ExtendedMovieDTO>> GetMovies()
        {
            return _mapper.Map<List<ExtendedMovieDTO>>(await _movieRepository.GetMovies());
        }

        public async Task<ExtendedMovieDTO> GetMovie(String id)
        {
            return _mapper.Map<ExtendedMovieDTO>(await _movieRepository.GetMovie(id));
        }

        public async Task<ExtendedMovieDTO> AddMovie(ExtendedMovieDTO movie)
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
