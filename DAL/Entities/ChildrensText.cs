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
        public int TranslationId { get; set; }
        public string  Author { get; set; } 
        public Translation Translation { get; set; }
    }
}
