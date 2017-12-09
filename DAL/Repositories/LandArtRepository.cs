using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using DAL.Contexts;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class LandArtRepository : IRepository<LandArt, int>
    {
        private GlobalGoalContext context;

        public LandArtRepository(GlobalGoalContext context)
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

        //Create
        public LandArt Create(LandArt t)
        {
            using (var db = GetContext())
            {
                var landArt = db.LandArts.Add(t);

                db.SaveChanges();
                return landArt;
            }
        }

        //Read
        public LandArt Read(int id)
        {
            using (var db = GetContext())
            {
                var landArt = db.LandArts
                .Include("Translation.TranslatedTexts.Language")
                .FirstOrDefault(x => x.Id == id);
                return landArt;
            }
        }

        //ReadAll
        public List<LandArt> ReadAll()
        {
            var landArt = new List<LandArt>();

            using (var db = GetContext())
            {
                landArt = db.LandArts
                .Include("Translation.TranslatedTexts.Language").ToList();
                return landArt;
            }
        }

        //Update
        public LandArt Update(LandArt t)
        {
            using (var db = GetContext())
            {
                var landArtToBeModified = db.LandArts.Include("Translation.TranslatedTexts.Language").FirstOrDefault(x => x.Id == t.Id);

                db.Entry(landArtToBeModified).CurrentValues.SetValues(t);
                foreach (var item in landArtToBeModified.Translation.TranslatedTexts)
                {
                    db.Entry(item).CurrentValues.SetValues(t.Translation.TranslatedTexts.FirstOrDefault(x => x.LanguageISO == item.LanguageISO && x.TranslationId == item.TranslationId));
                }
                db.SaveChanges();

                return t;
            }
        }

        //Delete
        public bool Delete(int id)
        {
            using (var db = GetContext())
            {
                var landArt = db.LandArts.Include("Translation.TranslatedTexts.Language").FirstOrDefault(x => x.Id == id);

                if (landArt == null) return false;
                //foreach (var item in landArt.Translation.TranslatedTexts)
                //{
                //    db.Translations.Remove(item);

                //}
                db.LandArts.Remove(landArt);
                return true;
            }
        }
    }
}
