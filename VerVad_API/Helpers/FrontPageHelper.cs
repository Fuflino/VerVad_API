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
    public class FrontPageHelper
    {          
        public DTOFrontPage GetFrontPageDTO(string language, FrontPage fp)
        {
            var texts = fp.Translation.TranslatedTexts.Where(x => x.LanguageISO == language);

            var DTO = new DTOFrontPage()
            {
                Id = fp.Id,
                ImgUrl = fp.ImgURL
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