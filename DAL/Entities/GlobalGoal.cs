using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class GlobalGoal
    {
        public int Id { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string ImgURL { get; set; }
        public string AudioURL { get; set; }
        public string VideoURL { get; set; }        

        public List<LandArt> LandArts { get; set; }
        public List<Artwork> Artworks { get; set; }
        public List<Sculpture> Sculptures { get; set; }
        public int TranslationId { get; set; }
        public Translation Translation { get; set; }
        public List<ChildrensText> ChildrensTexts { get; set; }     

    }
}
