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
        private IFrontPageRepository<FrontPage, int, string> frontPageRepository;
        //private IRepository<GlobalGoal, int> globalGoalRepository;

        public IFrontPageRepository<FrontPage, int, string> GetFrontPageRepository()
        {
            return frontPageRepository ?? (frontPageRepository = new FrontPageRepository(new GlobalGoalContext()));
        }

        //public IRepository<GlobalGoal, int> GetGlobalGoalRepository()
        //{
        //    return globalGoalRepository ?? (globalGoalRepository = new GlobalGoalRepository(new GlobalGoalContext()));
        //}


    }
}
