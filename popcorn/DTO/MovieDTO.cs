using System;
using System.Collections.Generic;
using popcorn.Models;

namespace popcorn.DTO
{
    public class CoreMovieDTO
    {
        public String IMDBMovieId { get; set; }
        public String Name { get; set; }
        public int Runtime { get; set; }
        public DateTime ReleaseDate { get; set; }
        public String Synopsis { get; set; }
        public double Rating { get; set; }
        public ICollection<TorrentDTO> Torrents { get; set; }
    }

    public class ExtendedMovieDTO : CoreMovieDTO
    {
        public ICollection<GenreDTO> Genres { get; set; }
        public ICollection<CoreActorDTO> Actors { get; set; }
    }
}
