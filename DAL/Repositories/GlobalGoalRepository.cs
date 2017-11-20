using DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class GlobalGoalRepository
    {
        private GlobalGoalContext context;
        
        public GlobalGoalRepository(GlobalGoalContext context)
        {
            this.context = context;
        }

    }
}
