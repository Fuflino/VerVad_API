using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class FrontPage
    {
        public int Id { get; set; }
        public string ImgURL { get; set; }
        public int TranslationId { get; set; }
        public virtual Translation Translation { get; set; }
    }
}
