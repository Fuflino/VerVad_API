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
    class ChildrensTextRepository : IRepository<ChildrensText, int>
    {
        private GlobalGoalContext context;

        public ChildrensTextRepository(GlobalGoalContext context)
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
        public ChildrensText Create(ChildrensText t)
        {
            using (var db = GetContext())
            {
                var childrensText = db.ChildrensTexts.Add(t);

                db.SaveChanges();
                return childrensText;
            }
        }

        [HttpGet]
        public ChildrensText Read(int id)
        {
            using (var db = GetContext())
            {
                var childrensText = db.ChildrensTexts
                .Include("Translation.TranslatedTexts.Language")
                .FirstOrDefault(x => x.Id == id);
                return childrensText;
            }
        }

        [HttpGet]
        public List<ChildrensText> ReadAll()
        {
            var childrensText = new List<ChildrensText>();

            using (var db = GetContext())
            {
                childrensText = db.ChildrensTexts
                .Include("Translation.TranslatedTexts.Language").ToList();
                return childrensText;
            }
        }

        [HttpPut]
        public ChildrensText Update(ChildrensText t)
        {
            using (var db = GetContext())
            {
                var ChildrensTextToBeModified = db.ChildrensTexts.Include("Translation.TranslatedTexts.Language").FirstOrDefault(x => x.Id == t.Id);

                db.Entry(ChildrensTextToBeModified).CurrentValues.SetValues(t);
                foreach (var item in ChildrensTextToBeModified.Translation.TranslatedTexts)
                {
                    db.Entry(item).CurrentValues.SetValues(t.Translation.TranslatedTexts.FirstOrDefault(x => x.LanguageISO == item.LanguageISO && x.TranslationId == item.TranslationId));
                }
                db.SaveChanges();

                return t;
            }
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            using (var db = GetContext())
            {
                var childrensText = db.ChildrensTexts.FirstOrDefault(x => x.Id == id);

                if (childrensText == null) return false;
                foreach (var item in childrensText.Translation.TranslatedTexts)
                {
                    db.Translations.Remove(item);

                }
                db.ChildrensTexts.Remove(childrensText);
                return true;
            }
        }
    }
}
