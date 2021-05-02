using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace popcorn.Models
{
    public class Torrent
    {
        [Key]
        public Guid TorrentId { get; set; }
        [Required]
        public Movie Movie { get; set; }
        public String IMDBMovieId { get; set; }
        public String MagnetLink { get; set; }
        public String Quality { get; set; }
        public int Seeds { get; set; }
        public int Peers { get; set; }
        public String FileSize { get; set; }
    }
}
