using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VerVad_API.Models
{
    public class DTOGlobalGoal
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public List<DTOChildrensText> ChildrensTexts { get; set; }
        public List<DTOChildrensArtwork> ChildrensArtworks { get; set; }
        public List<DTOLandArt> LandArt { get; set; }
        public DTOAudioVideo AudioVideo { get; set; }
        //public bool IsPublished { get; set; }
    }
}