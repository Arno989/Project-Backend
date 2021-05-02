using System;
using System.Collections.Generic;

namespace popcorn.DTO
{
    public class CoreActorDTO
    {
        public String IMDBActorId { get; set; }
        public String Name { get; set; }
        public DateTime Born { get; set; }
    }

    public class ExtendedActorDTO : CoreActorDTO
    {
        public ICollection<CoreMovieDTO> Movies { get; set; }
    }
}
