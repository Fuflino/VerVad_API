using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VerVad_API.Models
{
    public class DTOAudioVideo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SongArtist { get; set; }
        public string SongTitle { get; set; }
        public string MusicUrl { get; set; }
        public string VideoUrl { get; set; }      
    }
}