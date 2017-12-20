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
    [RoutePrefix("api/Landart")]

    public class LandArtController : ApiController
    {
        private readonly GlobalGoalChildrensHelper _helper = new GlobalGoalChildrensHelper();
        private readonly IRepository<LandArt, int> _repo = new Facade().GetLandArtRepository();

        private bool LandArtExists(int id, string language)
        {
            return _repo.Read(id) != null;
        }

        [HttpGet] //DTO
        [ResponseType(typeof(DTOLandArt))]
        public IHttpActionResult GetLandArt(int id, string language)
        {
            var landArt = _repo.Read(id);

            if (!LandArtExists(id, language))
            {
                return NotFound();
            }

            var DTO = _helper.GetLandArtDTO(language, landArt);

            return Ok(DTO);
        }

        [HttpGet] //DTO
        [ResponseType(typeof(List<DTOLandArt>))]
        public IHttpActionResult GetLandArts(string language)
        {
            var landArt = _repo.ReadAll();
            var DTOList = new List<DTOLandArt>();

            foreach (var item in landArt)
            {
                var DTO = _helper.GetLandArtDTO(language, item);
                DTOList.Add(DTO);
            }

            return Ok(DTOList);
        }

        [HttpGet]
        [ResponseType(typeof(List<LandArt>))]
        [Route("GetLandartFromGlobalGoal/{id:int}")]
        public IHttpActionResult GetLandartFromGlobalGoal(int id)
        {
            var landArt = _repo.GetAllInstances(id);
            if (landArt == null)
            {
                return NotFound();
            }
            return Ok(landArt);
        }

        [HttpGet]
        [ResponseType(typeof(LandArt))]
        public IHttpActionResult GetLandArt(int id)
        {
            var landArt = _repo.Read(id);
            if (landArt == null)
            {
                return NotFound();
            }
            return Ok(landArt);
        }

        [HttpPost]
        [ResponseType(typeof(LandArt))]
        public IHttpActionResult PostLandart(LandArt la)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var landArt = _repo.Create(la);
            return Ok(landArt);
        }

        [HttpPut]
        public IHttpActionResult PutLandArt(LandArt la)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var landArt = _repo.Update(la);
            if (landArt == null)
            {
                return NotFound();
            }
            return Ok(landArt);
        }

        [HttpDelete]
        public IHttpActionResult DeleteLandArt(int id)
        {

            var la =_repo.Delete(id);
            if (la == false)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
