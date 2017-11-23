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
        public List<DTOChildrensText> ChildrensTexts { get; set; }
        public List<DTOChildrensArtwork> ChildrensDrawings { get; set; }
        public List<DTOChildrensArtwork> ChildrensSculptures { get; set; }
        public List<DTOLandArt> LandArt { get; set; }
        public DTOAudio Audio { get; set; }
        public int Longitude { get; set; }
        public int Latitude { get; set; }       

    }
}