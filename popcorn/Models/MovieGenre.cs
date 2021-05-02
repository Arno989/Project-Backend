using System;
using System.ComponentModel.DataAnnotations;

namespace popcorn.Models
{
    public class MovieGenre
    {
        public String IMDBMovieId { get; set; }
        public Movie Movie { get; set; }
        public Guid GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
