using System;
using System.Collections.Generic;

namespace popcorn.DTO
{
    public class ActorDTO
    {
        public String IMDBActorId { get; set; }
        public String Name { get; set; }
        public DateTime Born { get; set; }
        public List<String> Movies { get; set; }
    }
}
