using DAL.Entities;
using DAL.Facade;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using VerVad_API.Helpers;
using VerVad_API.Models;

namespace VerVad_API.Controllers
{
    public class GlobalGoalController : ApiController
    {
        private IRepository<GlobalGoal, int, string> _repo = new Facade().GetGlobalGoalRepository();
        private GlobalGoalHelper _helper = new GlobalGoalHelper();

        [HttpGet]
        [ResponseType(typeof(GlobalGoal))]
        public IHttpActionResult GetGlobalGoal(int id, string language)
        {
            var globalGoal = _repo.Read(id, language);

            if (!GlobalGoalExists(id, language))
            {
                return NotFound();
            }

            var DTO = new DTOGlobalGoal()
            {
                Id = globalGoal.Id,
                ImgUrl = globalGoal.ImgURL,
                Latitude = globalGoal.Latitude,
                Longitude = globalGoal.Longitude,
                AudioVideo = new DTOAudioVideo()
                {
                    Title = globalGoal.AudioTitle,
                    Description = globalGoal.AudioDescription,
                    MusicUrl = globalGoal.AudioURL,
                    VideoUrl = globalGoal.VideoURL,
                    SongArtist = globalGoal.SongArtist,
                    SongTitle = globalGoal.SongTitle
                },
                ChildrensDrawings = new List<DTOChildrensArtwork>(),
                ChildrensSculptures = new List<DTOChildrensArtwork>(),
                ChildrensTexts = new List<DTOChildrensText>()
            };

            foreach (var item in globalGoal.ChildrensTexts)
            {
                var text = new DTOChildrensText();
                text.Author = item.Author;
                foreach (var item2 in item.Translation.TranslatedTexts)
                {
                    text.Title = item2.Title;
                    text.Description = item2.Description;
                }
                DTO.ChildrensTexts.Add(text);
            }

            foreach (var item in globalGoal.Artworks)
            {
                var drawings = new DTOChildrensArtwork();
                drawings.Artist = item.Artist;
                drawings.ImgUrl = item.ImgUrl;
                foreach (var item2 in item.Translation.TranslatedTexts)
                {
                    drawings.Title = item2.Title;
                    drawings.Description = item2.Description;
                }
                DTO.ChildrensDrawings.Add(drawings);
            }

            foreach (var item in globalGoal.Sculptures)
            {
                var sculptures = new DTOChildrensArtwork();
                sculptures.Artist = item.Artist;
                sculptures.ImgUrl = item.ImgUrl;
                foreach (var item2 in item.Translation.TranslatedTexts)
                {
                    sculptures.Title = item2.Title;
                    sculptures.Description = item2.Description;
                }
                DTO.ChildrensSculptures.Add(sculptures);
            }

            foreach (var item in globalGoal.Translation.TranslatedTexts)
            {
                DTO.Title = item.Title;
                DTO.Description = item.Description;
            };

            return Ok(DTO);
        }

        private bool GlobalGoalExists(int id, string language)
        {
            return _repo.Read(id, language) != null;
        }
    }
}
