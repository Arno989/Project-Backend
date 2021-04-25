using System;
using System.Collections.Generic;

namespace popcorn.DTO
{
    public class ActorDTO
    {
        public String IMDBActorId { get; set; }
        public String Name { get; set; }
        public int Age { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
