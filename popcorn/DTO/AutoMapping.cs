using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using popcorn.Models;

namespace popcorn.DTO
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Actor, CoreActorDTO>().ReverseMap();
            CreateMap<Actor, ExtendedActorDTO>()
                .ForMember(a => a.Movies, opt => opt.MapFrom(a => a.MovieActors.Select(ma => ma.Movie)));
            CreateMap<ExtendedActorDTO, Actor>();

            CreateMap<Genre, GenreDTO>().ReverseMap();

            CreateMap<Movie, CoreMovieDTO>().ReverseMap();
            CreateMap<Movie, ExtendedMovieDTO>()
                .ForMember(m => m.Actors, opt => opt.MapFrom(m => m.MovieActors.Select(ma => ma.Actor)))
                .ForMember(m => m.Genres, opt => opt.MapFrom(m => m.MovieGenres.Select(ma => ma.Genre)));
            // .ForMember(m => m.Torrents, opt => opt.MapFrom(m => m.Torrents.Where(t => t.IMDBMovieId == m.IMDBMovieId)));
            CreateMap<ExtendedMovieDTO, Movie>();

            CreateMap<Torrent, TorrentDTO>().ReverseMap();
        }
    }
}
