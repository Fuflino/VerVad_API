﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VerVad_API.Models
{
    public class DTOLandArt
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
    }
}