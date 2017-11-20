using DAL.Contexts;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class FrontPageRepository : IFrontPageRepository<FrontPage, int, string>
    {
        private GlobalGoalContext context;
        public FrontPageRepository(GlobalGoalContext context)
        {

            this.context = context;
        }


        public FrontPage Create(FrontPage t)
        {
            using (var db = GetContext())
            {
                db.FrontPage.Add(t);
                db.SaveChanges();
                return t;
            }
        }

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

        public FrontPage Read(int id, string language)
        {
            using (var db = GetContext())
            {
                var titlesWithLang = new List<Translation>();
                var descWithLang = new List<Translation>();
                var frontPage = db.FrontPage.Where(x => x.Translation.Id == id).FirstOrDefault();
                return frontPage;
            }

        }


        public FrontPage Update(FrontPage t)
        {

            using (var db = GetContext())
            {
                var FrontPageToUpdate = db.FrontPage.Include("Title").Include("Title.Texts").Include("Description").Include("Description.texts").FirstOrDefault(x => x.Id == t.Id);

                //db.ObjectCurrentStateModified(FrontPageToUpdate, t);
                db.SaveChanges();

                //db.ObjectCurrentStateModified(FrontPageToUpdate.Title, t.Title);
                db.SaveChanges();
                    
                //db.ObjectCurrentStateModified(FrontPageToUpdate.Description, t.Description);
                db.SaveChanges();

                //for (int i = 0; i < 2; i++)
                //{
                //    db.ObjectCurrentStateModified(FrontPageToUpdate.Description.Texts[i], t.Description.Texts[i]);
                //}
                //db.SaveChanges();

                //for (int i = 0; i < 2; i++)
                //{
                //    db.ObjectCurrentStateModified(FrontPageToUpdate.Title.Texts[i], t.Title.Texts[i]);
                //}
                db.SaveChanges();




                return t;
            }
        }

        private GlobalGoalContext GetContext()
        {
            if (context.GetType().FullName.Equals("DAL.Contexts.GlobalGoalContext"))
            {
                return new GlobalGoalContext();

            }
            return context;
        }
    }
}
