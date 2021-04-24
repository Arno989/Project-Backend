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
        public int Age { get; set; }
        public List<Movie> Movies { get; set; } // many to many
    }
}
