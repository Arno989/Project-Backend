using System;

namespace popcorn.DTO
{
    public class TorrentDTO
    {
        public Guid TorrentId { get; set; }
        public String IMDBMovieId { get; set; }
        public String MagnetLink { get; set; }
        public String Quality { get; set; }
        public int Seeds { get; set; }
        public int Peers { get; set; }
        public String FileSize { get; set; }
    }
}
