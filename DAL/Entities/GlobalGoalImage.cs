using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public abstract class GlobalGoalImage
    {
        public int Id { get; set; }
        public string ImgUrl { get; set; }
        public string Artist { get; set; } 
        public Translation Translation { get; set; }
    }

    public class LandArt : GlobalGoalImage
    {

    }    

    public class Artwork : GlobalGoalImage
    {

    }
}
