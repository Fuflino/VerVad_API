using DAL.Contexts;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class GlobalGoalRepository : IRepository<GlobalGoal, int, string>
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

        public GlobalGoal Create(GlobalGoal t, string language)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public GlobalGoal Read(int id)
        {
            using (var db = GetContext())
            {
                var globalGoal = db.Global_Goals
                .Include("Translation.TranslatedTexts.Language")
                .Include("Artworks.Translation.TranslatedTexts.Language")
                .Include("Sculptures.Translation.TranslatedTexts.Language")
                .Include("LandArts.Translation.TranslatedTexts.Language")
                .Include("ChildrensTexts.Translation.TranslatedTexts.Language")
                .FirstOrDefault(x => x.Id == id);         
                return globalGoal;
            }
        }

        public List<GlobalGoal> ReadAll()
        {
            var globalGoals = new List<GlobalGoal>();

            using (var db = GetContext())
            {
                globalGoals = db.Global_Goals
                .Include("Translation.TranslatedTexts.Language")
                .Include("Artworks.Translation.TranslatedTexts.Language")
                .Include("Sculptures.Translation.TranslatedTexts.Language")
                .Include("LandArts.Translation.TranslatedTexts.Language")
                .Include("ChildrensTexts.Translation.TranslatedTexts.Language").ToList();
                return globalGoals;
            }
        }

        public GlobalGoal Update(GlobalGoal t)
        {
            throw new NotImplementedException();
        }

    }
}
