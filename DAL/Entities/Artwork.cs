using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Artwork
    {
        public int Id { get; set; }
        public string ImgUrl { get; set; }
        public string Artist { get; set; }
        public virtual Translation Translation { get; set; }
        public virtual GlobalGoal GlobalGoal { get; set; }
        public int GlobalGoalId { get; set; }
    }
}
