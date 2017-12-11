using DAL.Contexts;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace DAL.Repositories
{
    public class GlobalGoalRepository : IRepository<GlobalGoal, int>
    {
        private GlobalGoalContext context;

        public GlobalGoalRepository(GlobalGoalContext context)
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
        public GlobalGoal Create(GlobalGoal t)
        {
            using (var db = GetContext())
            {
                var globalGoal = db.Global_Goals.Add(t);

                db.SaveChanges();
                return globalGoal;
            }
        }
        
        // Read
        public GlobalGoal Read(int id)
        {
            using (var db = GetContext())
            {
                var globalGoal = db.Global_Goals
                .Include("Translation.TranslatedTexts.Language")
                .Include("Artworks.Translation.TranslatedTexts.Language")
                .Include("LandArts.Translation.TranslatedTexts.Language")
                .Include("ChildrensTexts.Translation.TranslatedTexts.Language")
                .Include("AudioVideo.Translation.TranslatedTexts.Language")
                .FirstOrDefault(x => x.Id == id);
                return globalGoal;
            }
        }

        //ReadAll
        public List<GlobalGoal> ReadAll()
        {
            var globalGoals = new List<GlobalGoal>();

            using (var db = GetContext())
            {
                globalGoals = db.Global_Goals
                .Include("Translation.TranslatedTexts.Language")
                .Include("Artworks.Translation.TranslatedTexts.Language")
                .Include("LandArts.Translation.TranslatedTexts.Language")
                .Include("ChildrensTexts.Translation.TranslatedTexts.Language")
                .Include("AudioVideo.Translation.TranslatedTexts.Language").ToList();
                return globalGoals;
            }
        }

        //Update
        public GlobalGoal Update(GlobalGoal t)
        {
            using (var db = GetContext())
            {
                var globalGoalToBeModified = db.Global_Goals.Include("Translation.TranslatedTexts.Language").FirstOrDefault(x => x.Id == t.Id);

                db.Entry(globalGoalToBeModified).CurrentValues.SetValues(t);
                foreach (var item in globalGoalToBeModified.Translation.TranslatedTexts)
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
                var gg = db.Global_Goals
                .Include("Translation.TranslatedTexts.Language")
                .Include("Artworks.Translation.TranslatedTexts.Language")
                .Include("LandArts.Translation.TranslatedTexts.Language")
                .Include("ChildrensTexts.Translation.TranslatedTexts.Language")
                .Include("AudioVideo.Translation.TranslatedTexts.Language")
                .FirstOrDefault(x => x.Id == id);

                var translations = gg.Translation.TranslatedTexts.ToList();
                if (gg == null) return false;

                foreach (var item in translations)
                {
                    db.Translations.Remove(item);

                }

                if (gg.LandArts != null)
                {
                    foreach (var item in gg.LandArts.ToList())
                    {
                        foreach (var item2 in item.Translation.TranslatedTexts.ToList())
                        {
                            db.Translations.Remove(item2);
                        }
                        db.LandArts.Remove(item);
                    }
                }

                if (gg.Artworks != null)
                {
                    foreach (var item in gg.Artworks.ToList())
                    {
                        foreach (var item2 in item.Translation.TranslatedTexts.ToList())
                        {
                            db.Translations.Remove(item2);
                        }
                        db.Artworks.Remove(item);
                    }
                }

                if (gg.ChildrensTexts != null)
                {
                    foreach (var item in gg.ChildrensTexts.ToList())
                    {
                        foreach (var item2 in item.Translation.TranslatedTexts.ToList())
                        {
                            db.Translations.Remove(item2);
                        }
                        db.ChildrensTexts.Remove(item);
                    }
                }

                if (gg.AudioVideo != null)
                {
                    foreach (var item2 in gg.AudioVideo.Translation.TranslatedTexts.ToList())
                    {
                        db.Translations.Remove(item2);
                    }
                    db.AudioVideos.Remove(gg.AudioVideo);
                }
                db.Global_Goals.Remove(gg);
                db.SaveChanges();
                return true;
            }
        }

    }
}
