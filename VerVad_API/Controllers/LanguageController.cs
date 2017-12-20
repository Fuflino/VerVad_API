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

namespace VerVad_API.Controllers
{

    public class LanguageController : ApiController
    {
        private readonly ILanguageRepository<Language, string> _repo = new Facade().GetLanguageRepository();

        [HttpGet]
        [ResponseType(typeof(List<Language>))]
        public IHttpActionResult GetLanguages()
        {
            var language = _repo.ReadAll();
            if (language == null)
            {
                return NotFound();
            }
            return Ok(language);
        }
    }
}
