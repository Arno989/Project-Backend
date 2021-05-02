using System;
using System.ComponentModel.DataAnnotations;

namespace popcorn.Models
{
    public class MovieActor
    {
        public String IMDBMovieId { get; set; }
        public Movie Movie { get; set; }
        public String IMDBActorId { get; set; }
        public Actor Actor { get; set; }
    }
}
