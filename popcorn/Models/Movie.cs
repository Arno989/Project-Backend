using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace popcorn.Models
{
    public class Movie
    {
        [Key]
        public String IMDBMovieId { get; set; }
        [Required]
        public String Name { get; set; }
        public int Runtime { get; set; }
        public DateTime ReleaseDate { get; set; }
        public String Synopsis { get; set; }
        public List<String> Genres { get; set; } // many to many
        public double Rating { get; set; }
        public List<Actor> Actors { get; set; } // many to many
        public List<Torrent> Torrents { get; set; }
    }
}
