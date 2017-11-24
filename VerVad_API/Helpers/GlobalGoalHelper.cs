using DAL.Entities;
using DAL.Facade;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VerVad_API.Helpers
{
    public class GlobalGoalHelper
    {
        private IRepository<GlobalGoal, int, string> _repo = new Facade().GetGlobalGoalRepository();
        public string GetTitle(string language, GlobalGoal gg)
        {
            string title = "";
            var translation = gg.Translation.TranslatedTexts.Where(x => x.LanguageISO == language).ToList();

            foreach (var item in translation)
            {
                title = item.Title;
            }

            return title;
        }

        public string GetDescription(string language, GlobalGoal gg)
        {
            string descr = "";
            var translation = gg.Translation.TranslatedTexts.Where(x => x.LanguageISO == language).ToList();

            foreach (var item in translation)
            {
                descr = item.Description;
            }

            return descr;
        }

       
    }
}