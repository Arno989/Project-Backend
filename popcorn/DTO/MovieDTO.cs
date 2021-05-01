using System;
using System.Collections.Generic;

namespace popcorn.DTO
{
    public class MovieDTO
    {
        public String IMDBMovieId { get; set; }
        public String Name { get; set; }
        public int Runtime { get; set; }
        public DateTime ReleaseDate { get; set; }
        public String Synopsis { get; set; }
        public List<String> Genres { get; set; }
        public double Rating { get; set; }
        public List<String> Actors { get; set; }
        public List<Guid> Torrents { get; set; }
    }
}
