﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class LandArt
    {
        public int Id { get; set; }
        public string ImgUrl { get; set; }
        public int TranslationId { get; set; }
        public virtual Translation Translation { get; set; }
        public virtual GlobalGoal GlobalGoal { get; set; }
        public int GlobalGoalId { get; set; }
    }
}
