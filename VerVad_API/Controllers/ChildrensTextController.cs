using DAL.Entities;
using DAL.Facade;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using VerVad_API.Helpers;
using VerVad_API.Models;

namespace VerVad_API.Controllers
{
    [RoutePrefix("api/ChildrensText")]

    public class ChildrensTextController : ApiController
    {
        private GlobalGoalChildrensHelper _helper = new GlobalGoalChildrensHelper();
        private IRepository<ChildrensText, int> _repo = new Facade().GetChildrensTextRepository();

        private bool ChildrensTextExists(int id, string language)
        {
            return _repo.Read(id) != null;
        }

        [HttpGet] //DTO
        [ResponseType(typeof(DTOChildrensText))]
        public IHttpActionResult GetChildrensText(int id, string language) 
        {
            var ct = _repo.Read(id);

            if (!ChildrensTextExists(id, language))
            {
                return NotFound();
            }

            var DTO = _helper.GetChildrensTextDTO(language, ct);

            return Ok(DTO);
        }

        [HttpGet] //DTO
        [ResponseType(typeof(List<DTOChildrensText>))]
        public IHttpActionResult GetChildrensText(string language) 
        {
            var ct = _repo.ReadAll();
            var DTOList = new List<DTOChildrensText>();

            foreach (var item in ct)
            {
                var DTO = _helper.GetChildrensTextDTO(language, item);
                DTOList.Add(DTO);
            }

            return Ok(DTOList);
        }

        [HttpGet]
        [ResponseType(typeof(List<ChildrensText>))]
        [Route("GetTextsFromGlobalGoal/{id:int}")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult GetTextsFromGlobalGoal(int id)
        {
            var texts = _repo.GetAllInstances(id);
            return Ok(texts);
        }

        [HttpGet]
        [ResponseType(typeof(ChildrensText))]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult GetChildrensTexts(int id)
        {
            var text = _repo.Read(id);
            return Ok(text);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult PostChildrensText(ChildrensText ct)
        {
            var text = _repo.Create(ct);
            return Ok(text);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult PutChildrensText(ChildrensText ct)
        {
            var toUpdate = _repo.Update(ct);
            return Ok(toUpdate);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult DeleteChildrensText(int id)
        {
            _repo.Delete(id);
            return Ok();
        }

    }
}
