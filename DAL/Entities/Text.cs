using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Text
    {
        public int Id { get; set; }
        public Language Language { get; set; }
        public string TranslatedText { get; set; }
    }
}
