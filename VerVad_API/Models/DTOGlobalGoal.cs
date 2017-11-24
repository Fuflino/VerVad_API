﻿using System;
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
        public DTOAudioVideo AudioVideo { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }       

    }
}