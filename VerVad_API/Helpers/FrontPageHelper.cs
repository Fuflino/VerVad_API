using DAL.Entities;
using DAL.Facade;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VerVad_API.Helpers
{
    public class FrontPageHelper
    {
        private IFrontPageRepository<FrontPage, int, string> frontPageRepository = new Facade().GetFrontPageRepository();
        public string GetTitle(string language, FrontPage fp)
        {
            string title = "";
            var translations = fp.Translation.TranslatedTexts.Where(x => x.LanguageISO == language).ToList();
            
            foreach(var element in translations)
            {
                title = element.Title;
            }

            return title;
        }

        public string GetDescription(string language, FrontPage fp)
        {
            string descr = "";
            var translations = fp.Translation.TranslatedTexts.Where(x => x.LanguageISO == language).ToList();

            foreach (var element in translations)
            {
                descr = element.Description;
            }

            return descr;
        }


    }
}