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
    public class LanguageRepository : IRepository<Language, string>
    {
        private GlobalGoalContext context;
        public LanguageRepository(GlobalGoalContext context){
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

        public Language Create(Language t)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Language Read(string id)
        {
            using (var db = GetContext())
            {
                return db.Languages.FirstOrDefault(x => x.ISO == id);
            }
        }

        public List<Language> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Language Update(Language t)
        {
            throw new NotImplementedException();
        }
    }
}
