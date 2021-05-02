using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace popcorn.Models
{
    public class Actor
    {
        [Key]
        public String IMDBActorId { get; set; }
        [Required]
        public String Name { get; set; }
        public DateTime Born { get; set; }
        public ICollection<MovieActor> MovieActors { get; set; }
    }
}
