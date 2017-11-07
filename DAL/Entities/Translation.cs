using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Translation 
    {
        public int Id { get; set; }
        public List<Text> Texts { get; set; }
    }
} 
