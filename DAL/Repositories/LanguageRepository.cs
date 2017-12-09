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
    public class LanguageRepository : ILanguageRepository<Language, string>
    {
        private GlobalGoalContext context;

        public LanguageRepository(GlobalGoalContext context)
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

        //Read
        public Language Read(string id)
        {
            using (var db = GetContext())
            {
                return db.Languages.FirstOrDefault(x => x.ISO == id);
            }
        }

        //ReadAll
        public List<Language> ReadAll()
        {
            using (var db = GetContext())
            {
                return db.Languages.ToList();
            }
        }
    }
}
