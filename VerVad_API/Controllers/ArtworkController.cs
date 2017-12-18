using DAL.Entities;
using DAL.Facade;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using DAL.Interfaces;
using VerVad_API.Helpers;
using VerVad_API.Models;

namespace VerVad_API.Controllers
{
    [RoutePrefix("api/Artwork")]
    public class ArtworkController : ApiController
    {
        private GlobalGoalChildrensHelper _helper = new GlobalGoalChildrensHelper();
        private IRepository<Artwork, int> _repo = new Facade().GetArtworkRepository();

        private bool ArtworkExists(int id, string language)
        {
            return _repo.Read(id) != null;
        }

        [HttpGet] //DTO
        [ResponseType(typeof(DTOChildrensArtwork))]
        public IHttpActionResult GetArtwork(int id, string language)
        {
            var aw = _repo.Read(id);

            if (!ArtworkExists(id, language))
            {
                return NotFound();
            }

            var DTO = _helper.GetArtworkDTO(language, aw);

            return Ok(DTO);
        }

        [HttpGet] //DTO
        [ResponseType(typeof(List<DTOChildrensArtwork>))]
        public IHttpActionResult GetArtworks(string language)
        {
            var aw = _repo.ReadAll();
            var DTOList = new List<DTOChildrensArtwork>();

            foreach (var item in aw)
            {
                var DTO = _helper.GetArtworkDTO(language, item);
                DTOList.Add(DTO);
            }

            return Ok(DTOList);
        }

        [HttpGet]
        [ResponseType(typeof(List<Artwork>))]
        [Route("GetArtworksFromGlobalGoal/{id:int}")]
        public IHttpActionResult GetArtworksFromGlobalGoal(int id)
        {
            var aw = _repo.GetAllInstances(id);
            return Ok(aw);
        }

        [HttpGet]
        [ResponseType(typeof(Artwork))]
        public IHttpActionResult GetArtworks(int id)
        {
            var text = _repo.Read(id);

            return Ok(text);
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        public IHttpActionResult PostArtwork(Artwork aw)
        {
            var text = _repo.Create(aw);
            return Ok(aw);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult PutArtwork(Artwork aw)
        {
            var toUpdate = _repo.Update(aw);
            return Ok(toUpdate);
        }

        [HttpDelete]
        public IHttpActionResult DeleteArtwork(int id)
        {
            _repo.Delete(id);
            return Ok();
        }
    }
}