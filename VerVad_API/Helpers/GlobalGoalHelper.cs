using DAL.Entities;
using DAL.Facade;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VerVad_API.Models;

namespace VerVad_API.Helpers
{
    public class GlobalGoalHelper
    {
        public DTOGlobalGoal GetGlobalGoalDTO(string language, GlobalGoal gg)
        {
            var texts = gg.Translation.TranslatedTexts.Where(x => x.LanguageISO == language);


            var DTO = new DTOGlobalGoal()
            {
                Id = gg.Id,
                ImgUrl = gg.ImgURL,
                Latitude = gg.Latitude,
                Longitude = gg.Longitude,

                AudioVideo = new DTOAudioVideo
                {
                    VideoUrl = gg.VideoURL,
                    MusicUrl = gg.AudioURL,
                    SongArtist = gg.SongArtist,
                    SongTitle = gg.SongTitle,
                    Description = gg.AudioDescription,
                    Title = gg.AudioTitle
                },
                ChildrensDrawings = new List<DTOChildrensArtwork>(),
                ChildrensSculptures = new List<DTOChildrensArtwork>(),
                ChildrensTexts = new List<DTOChildrensText>(),
                LandArt = new List<DTOLandArt>()
            };

            foreach (var item in gg.ChildrensTexts)
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

            foreach (var item in gg.Artworks)
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

            foreach (var item in gg.Sculptures)
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

            foreach (var item in gg.LandArts)
            {
                var landArt = new DTOLandArt();
                landArt.ImgUrl = item.ImgUrl;
                foreach (var item2 in item.Translation.TranslatedTexts)
                {
                    landArt.Title = item2.Title;
                    landArt.Description = item2.Description;
                }
                DTO.LandArt.Add(landArt);
            }

            foreach (var item in gg.Translation.TranslatedTexts)
            {
                DTO.Title = item.Title;
                DTO.Description = item.Description;
            };
            return DTO;
        }

    }
}