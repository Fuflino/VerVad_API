using DAL.Contexts;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace DAL.Repositories
{
    public class FrontPageRepository : IFrontPageRepository<FrontPage, int>
    {
        private GlobalGoalContext context;
        public FrontPageRepository(GlobalGoalContext context)
        {
            this.context = context;
        }

        private GlobalGoalContext GetContext()
        {
            if (context.GetType().FullName.Equals("DAL.Contexts.GlobalGoalContext"))
            {
                return new GlobalGoalContext();
            }
            return context;
        }

        [HttpPost]
        public FrontPage Create(FrontPage t)
        {
            using (var db = GetContext())
            {
                var frontPage = db.FrontPage.Add(t);

                db.SaveChanges();
                return t;
            }
        }

        [HttpGet]
        public FrontPage Read(int id)
        {
            using (var db = GetContext())
            {
                try
                {
                    var frontPage = db.FrontPage
                        .Include("Translation.TranslatedTexts.Language")
                        .FirstOrDefault(x => x.Id == id);
                    return frontPage;
                }
                catch
                {
                    throw;
                }
            }
        }

        [HttpPut]
        public FrontPage Update(FrontPage t)
        {
            using (var db = GetContext())
            {
                var frontPageToUpdate = db.FrontPage.Include("Translation.TranslatedTexts.Language").FirstOrDefault(x => x.Id == t.Id);
                db.Entry(frontPageToUpdate).CurrentValues.SetValues(t);
                foreach (var item in frontPageToUpdate.Translation.TranslatedTexts)
                {
                    db.Entry(item).CurrentValues.SetValues(t.Translation.TranslatedTexts.FirstOrDefault(x => x.LanguageISO == item.LanguageISO && x.TranslationId == item.TranslationId));
                }
                db.SaveChanges();
                return t;
            }
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            using (var db = GetContext())
            {
                var toBeDeleted = db.FrontPage.FirstOrDefault(x => x.Id == id);
                db.FrontPage.Remove(toBeDeleted);
                db.SaveChanges();

                //Translations should be removed aswell - TODO

                return true;
            }
        }
    }
}
