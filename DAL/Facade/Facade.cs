using DAL.Contexts;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Facade
{
    public class Facade
    {
        private IFrontPageRepository<FrontPage, int> frontPageRepository;
        private IRepository<GlobalGoal, int> globalGoalRepository;
        private IRepository<Language, string> languagelRepository;

        public IFrontPageRepository<FrontPage, int> GetFrontPageRepository()
        {
            return frontPageRepository ?? (frontPageRepository = new FrontPageRepository(new GlobalGoalContext()));
        }

        public IRepository<GlobalGoal, int> GetGlobalGoalRepository()
        {
            return globalGoalRepository ?? (globalGoalRepository = new GlobalGoalRepository(new GlobalGoalContext()));
        }

        public IRepository<Language, string> GetLanguageRepository()
        {
            return languagelRepository ?? (languagelRepository = new LanguageRepository(new GlobalGoalContext()));
        }
    }
}
