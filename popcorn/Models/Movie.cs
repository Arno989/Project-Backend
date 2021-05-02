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
        public ICollection<MovieGenre> MovieGenres { get; set; }
        public double Rating { get; set; }
        public ICollection<MovieActor> MovieActors { get; set; }
        public ICollection<Torrent> Torrents { get; set; }
    }
}
