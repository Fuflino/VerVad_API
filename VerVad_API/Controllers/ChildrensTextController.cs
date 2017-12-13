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

        [HttpGet]
        [ResponseType(typeof(List<ChildrensText>))]
        [Route("GetTextsFromGlobalGoal/{id:int}")]
        public IHttpActionResult GetTextsFromGlobalGoal(int id)
        {
            var texts = _repo.GetAllInstances(id);
            return Ok(texts);
        }

        [HttpGet]
        [ResponseType(typeof(ChildrensText))]
        public IHttpActionResult GetChildrensTexts(int id)
        {
            var text = _repo.Read(id);
            return Ok(text);
        }

        [HttpPost]
        public IHttpActionResult PostChildrensText(ChildrensText ct)
        {
            var text = _repo.Create(ct);
            return Ok(text);
        }

        [HttpPut]
        public IHttpActionResult PutChildrensText(ChildrensText ct)
        {
            var toUpdate = _repo.Update(ct);
            return Ok(toUpdate);
        }

        [HttpDelete]
        public IHttpActionResult DeleteChildrensText(int id)
        {
            _repo.Delete(id);
            return Ok();
        }

    }
}
