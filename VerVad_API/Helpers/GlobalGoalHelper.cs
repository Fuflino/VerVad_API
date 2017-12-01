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
        /// Change parameter in url, so it becomes a direct download link.
        public string ConvertToDDL(string audioUrl)
        {
            return audioUrl = audioUrl.Remove(audioUrl.Length - 1, 1) + "1";
        }

        public DTOGlobalGoal GetGlobalGoalDTO(string language, GlobalGoal gg)
        {
            var texts = gg.Translation.TranslatedTexts.Where(x => x.LanguageISO == language);

            var DTO = new DTOGlobalGoal()
            {
                Id = gg.Id,
                ImgUrl = gg.ImgURL,
                Latitude = gg.Latitude,
                Longitude = gg.Longitude,

                ChildrensArtworks = new List<DTOChildrensArtwork>(),                
                ChildrensTexts = new List<DTOChildrensText>(),
                LandArt = new List<DTOLandArt>(),
                AudioVideo = new DTOAudioVideo()
                {
                    Id = gg.AudioVideo.Id,
                    SongArtist = gg.AudioVideo.SongArtist,
                    SongTitle = gg.AudioVideo.SongTitle,
                    MusicUrl = gg.AudioVideo.AudioURL,
                    VideoUrl = gg.AudioVideo.VideoURL
                }
            };

            foreach (var item2 in gg.AudioVideo.Translation.TranslatedTexts.Where(x => x.LanguageISO == language))
            {
                DTO.AudioVideo.Title = item2.Title;
                DTO.AudioVideo.Description = item2.Description;
            }


            foreach (var item in gg.ChildrensTexts)
            {
                var text = new DTOChildrensText();
                text.Author = item.Author;
                text.Id = item.Id;

                foreach (var item2 in item.Translation.TranslatedTexts.Where(x => x.LanguageISO == language))
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
                drawings.Id = item.Id;

                foreach (var item2 in item.Translation.TranslatedTexts.Where(x => x.LanguageISO == language))
                {
                    drawings.Title = item2.Title;
                    drawings.Description = item2.Description;
                }

                DTO.ChildrensArtworks.Add(drawings);
            }
         
            foreach (var item in gg.LandArts)
            {
                var landArt = new DTOLandArt();
                landArt.ImgUrl = item.ImgUrl;
                landArt.Id = item.Id;

                foreach (var item2 in item.Translation.TranslatedTexts.Where(x => x.LanguageISO == language))
                {
                    landArt.Title = item2.Title;
                    landArt.Description = item2.Description;
                }

                DTO.LandArt.Add(landArt);
            }

            foreach (var item in texts)
            {
                DTO.Title = item.Title;
                DTO.Description = item.Description;
            };

            return DTO;
        }

    }
}