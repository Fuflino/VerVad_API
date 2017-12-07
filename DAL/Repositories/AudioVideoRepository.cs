﻿using DAL.Contexts;
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
    public class AudioVideoRepository : IRepository<AudioVideo, int>
    {
        private GlobalGoalContext context;

        public AudioVideoRepository(GlobalGoalContext context)
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
        public AudioVideo Create(AudioVideo t)
        {
            using (var db = GetContext())
            {
                var audioVideo = db.AudioVideos.Add(t);

                db.SaveChanges();
                return audioVideo;
            }
        }

        [HttpGet]
        public AudioVideo Read(int id)
        {
            using (var db = GetContext())
            {
                var audioVideo = db.AudioVideos
                .Include("Translation.TranslatedTexts.Language")
                .FirstOrDefault(x => x.Id == id);
                return audioVideo;
            }
        }

        [HttpGet]
        public List<AudioVideo> ReadAll()
        {
            var audioVideo = new List<AudioVideo>();

            using (var db = GetContext())
            {
                audioVideo = db.AudioVideos
                .Include("Translation.TranslatedTexts.Language").ToList();
                return audioVideo;
            }
        }

        [HttpPut]
        public AudioVideo Update(AudioVideo t)
        {
            using (var db = GetContext())
            {
                var audioVideoToBeModified = db.AudioVideos.Include("Translation.TranslatedTexts.Language").FirstOrDefault(x => x.Id == t.Id);

                db.Entry(audioVideoToBeModified).CurrentValues.SetValues(t);
                foreach (var item in audioVideoToBeModified.Translation.TranslatedTexts)
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
                var audioVideo = db.AudioVideos.Include("Translation.TranslatedTexts.Language").FirstOrDefault(x => x.Id == id);

                if (audioVideo == null) return false;
                //foreach (var item in AudioVideo.Translation.TranslatedTexts)
                //{
                //    db.Translations.Remove(item);

                //}
                db.AudioVideos.Remove(audioVideo);
                return true;
            }
        }

    }
}