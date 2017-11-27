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

        private bool GlobalGoalExists(int id, string language)
        {
            return _repo.Read(id, language) != null;
        }

        [HttpGet]
        [ResponseType(typeof(GlobalGoal))]
        public IHttpActionResult GetGlobalGoal(int id, string language)
        {
            var globalGoal = _repo.Read(id, language);

            if (!GlobalGoalExists(id, language))
            {
                return NotFound();
            }

            var DTO = _helper.GetGlobalGoalDTO(language, globalGoal);

            return Ok(DTO);
        }

    }
}
