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
    [RoutePrefix("api/GlobalGoal")]

    public class GlobalGoalController : ApiController
    {
        private IGGAndAVRepository<GlobalGoal, int> _repo = new Facade().GetGlobalGoalRepository();
        private GlobalGoalHelper _helper = new GlobalGoalHelper();

        private bool GlobalGoalExists(int id, string language)
        {
            return _repo.Read(id) != null;
        }

        [HttpGet] //DTO
        [ResponseType(typeof(DTOGlobalGoal))]
        public IHttpActionResult GetGlobalGoal(int id, string language)
        {
            var globalGoal = _repo.Read(id);

            if (!GlobalGoalExists(id, language))
            {
                return NotFound();
            }

            var DTO = _helper.GetGlobalGoalDTO(language, globalGoal);

            return Ok(DTO);
        }

        [HttpGet] //DTO
        [ResponseType(typeof(List<DTOGlobalGoal>))]
        public IHttpActionResult GetGlobalGoals(string language)
        {
            var globalGoals = _repo.ReadAll().Where(x => x.IsPublished == true);            
            var DTOList = new List<DTOGlobalGoal>();

            foreach (var item in globalGoals)
            {
                var DTO = _helper.GetGlobalGoalDTO(language, item);
                DTOList.Add(DTO);
            }

            return Ok(DTOList);
        }

        [HttpGet]
        [ResponseType(typeof(GlobalGoal))]
        [Authorize(Roles ="Admin")]
        public IHttpActionResult GetGlobalGoal(int id)
        {
            var globalGoal = _repo.Read(id);

            if (!GlobalGoalExists(id, "da"))
            {
                return NotFound();
            }

            return Ok(globalGoal);
        }

        [HttpGet]
        [ResponseType(typeof(List<GlobalGoal>))]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult GetGlobalGoals()
        {
            var ggs = _repo.ReadAll();
            if(ggs == null)
            {
                return NotFound();
            }
            return Ok(ggs);
        }

        [HttpPost]
        [ResponseType(typeof(GlobalGoal))]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult PostGlobalGoal(GlobalGoal gg)
        {
            var globalGoal = _repo.Create(gg);
            if (globalGoal == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(globalGoal);
        }

        [HttpPut]
        [ResponseType(typeof(GlobalGoal))]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult PutGlobalGoal(GlobalGoal gg)
        {
            var globalGoal = _repo.Update(gg);
            if (globalGoal == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(globalGoal);
        }

        [HttpDelete]
        [ResponseType(typeof(GlobalGoal))]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult DeleteGlobalGoal(int id)
        {
            var gg =_repo.Delete(id);
            if (gg == false)
            {
                return NotFound();
            }
            return Ok();
        }

        // Test method... - ConvertToDDL() can be found in the globalgGoal helper class
        [HttpGet]
        public string ReturnDDL(string audioUrl)
        {
            return audioUrl = _helper.ConvertToDDL(audioUrl);
        }

    }
}
