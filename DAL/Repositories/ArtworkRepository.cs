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
    public class ArtworkRepository : IRepository<Artwork, int>
    {
        private GlobalGoalContext context;

        public ArtworkRepository(GlobalGoalContext context)
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

        //Read by GlobaGoal id
        public List<Artwork> GetAllInstances(int gg_id)
        {
            var artworks = new List<Artwork>();
            using (var db = GetContext())
            {
                artworks = db.Global_Goals
                    .Include("Artworks.Translation.TranslatedTexts.Language")
                    .FirstOrDefault(x => x.Id == gg_id)
                    .Artworks.ToList();
                return artworks;
            }
        }

        //Create
        public Artwork Create(Artwork t)
        {
            using (var db = GetContext())
            {
                var Artworks = db.Artworks.Add(t);

                db.SaveChanges();
                return Artworks;
            }
        }

        //Read
        public Artwork Read(int id)
        {
            using (var db = GetContext())
            {
                var Artworks = db.Artworks
                .Include("Translation.TranslatedTexts.Language")
                .FirstOrDefault(x => x.Id == id);
                return Artworks;
            }
        }

        //ReadAll
        public List<Artwork> ReadAll()
        {
            var Artworks = new List<Artwork>();

            using (var db = GetContext())
            {
                Artworks = db.Artworks
                .Include("Translation.TranslatedTexts.Language").ToList();
                return Artworks;
            }
        }

        //Update
        public Artwork Update(Artwork t)
        {
            using (var db = GetContext())
            {
                var artworkToBeModified = db.Artworks.Include("Translation.TranslatedTexts.Language").FirstOrDefault(x => x.Id == t.Id);

                db.Entry(artworkToBeModified).CurrentValues.SetValues(t);
                foreach (var item in artworkToBeModified.Translation.TranslatedTexts)
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
                var artwork = db.Artworks.Include("Translation.TranslatedTexts.Language").FirstOrDefault(x => x.Id == id);

                if (artwork == null) return false;
                foreach (var item in artwork.Translation.TranslatedTexts.ToList())
                {
                    db.Translations.Remove(item);

                }
                db.Artworks.Remove(artwork);
                db.SaveChanges();
                return true;
            }
        }
    }
}
