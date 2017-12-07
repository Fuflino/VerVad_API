using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VerVad_API.Models;

namespace VerVad_API.Helpers
{
    public class GlobalGoalChildrensHelper
    {
        public DTOLandArt GetLandArtDTO(string language, LandArt la)
        {
            var texts = la.Translation.TranslatedTexts.Where(x => x.LanguageISO == language);

            var DTO = new DTOLandArt()
            {
                Id = la.Id,
                ImgUrl = la.ImgUrl
            };

            foreach (var item in texts)
            {
                DTO.Title = item.Title;
                DTO.Description = item.Description;
            }
            return DTO;
        }

        public DTOChildrensArtwork GetArtworktDTO(string language, Artwork aw)
        {
            var texts = aw.Translation.TranslatedTexts.Where(x => x.LanguageISO == language);

            var DTO = new DTOChildrensArtwork()
            {
                Id = aw.Id,
                ImgUrl = aw.ImgUrl,
                Artist = aw.Artist
            };

            foreach (var item in texts)
            {
                DTO.Title = item.Title;
                DTO.Description = item.Description;
            }
            return DTO;
        }

        public DTOChildrensText GetChildrensTextDTO(string language, ChildrensText ct)
        {
            var texts = ct.Translation.TranslatedTexts.Where(x => x.LanguageISO == language);

            var DTO = new DTOChildrensText()
            {
                Id = ct.Id,
                Author = ct.Author
            };

            foreach (var item in texts)
            {
                DTO.Title = item.Title;
                DTO.Description = item.Description;
            }
            return DTO;
        }

        public DTOAudioVideo GetAudioVideoDTO(string language, AudioVideo av)
        {
            var texts = av.Translation.TranslatedTexts.Where(x => x.LanguageISO == language);

            var DTO = new DTOAudioVideo()
            {
                Id = av.Id,
                MusicUrl = av.AudioURL,
                SongArtist = av.SongArtist,
                SongTitle = av.SongTitle,
                VideoUrl = av.VideoURL
            };

            foreach (var item in texts)
            {
                DTO.Title = item.Title;
                DTO.Description = item.Description;
            }
            return DTO;
        }

    }
}