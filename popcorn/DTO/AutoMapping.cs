using System;
using System.Collections.Generic;
using AutoMapper;
using popcorn.Models;

namespace popcorn.DTO
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {

            CreateMap<Actor, ActorDTO>();
            CreateMap<ActorDTO, Actor>();
            CreateMap<Movie, MovieDTO>();
            CreateMap<MovieDTO, Movie>();
            CreateMap<Torrent, TorrentDTO>();
            CreateMap<TorrentDTO, Torrent>();

        }
    }
}
