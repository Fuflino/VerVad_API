using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ChildrensText
    {
        public int Id { get; set; }
        public Translation Title { get; set; }

        public Translation Text { get; set; } 
    }
}
