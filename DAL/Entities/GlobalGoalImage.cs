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
        public string ImageUrl { get; set; }
    }

    public class LandArt : GlobalGoalImage
    {

    }

    public class Sculpture : GlobalGoalImage
    {

    }

    public class Artwork : GlobalGoalImage
    {

    }
}
