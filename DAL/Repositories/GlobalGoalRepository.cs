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

        [HttpPost]
        public GlobalGoal Create(GlobalGoal t)
        {
            using (var db = GetContext())
            {
                var globalGoal = db.Global_Goals.Add(t);

                db.SaveChanges();
                return globalGoal;
            }
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
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

        [HttpGet]
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

        [HttpPut]
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

    }
}
