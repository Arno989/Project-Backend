using System;
using System.Collections.Generic;

namespace popcorn.Models
{
    public class Genre
    {
        public Guid GenreId { get; set; }
        public String Name { get; set; }
        public ICollection<MovieGenre> MovieGenres { get; set; }
    }
}
