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
    [RoutePrefix("api/ChildrensText")]
    public class ArtworkController : ApiController
    {
        // GET: Artwork
        private GlobalGoalChildrensHelper _helper = new GlobalGoalChildrensHelper();
        private IRepository<Artwork, int> _repo = new Facade().GetArtworkRepository();

        [HttpGet]
        [ResponseType(typeof(List<DTOChildrensArtwork>))]
        [Route("GetArtworksFromGlobalGoal/{id:int}")]
        public IHttpActionResult GetArtworksFromGlobalGoal(int id, string language)
        {
            var artworks = _repo.GetAllInstances(id);
            var dtoList = artworks.Select(item => _helper.GetArtworkDTO(language, item)).ToList();
            return Ok(dtoList);
        }

        [HttpGet]
        [ResponseType(typeof(Artwork))]
        public IHttpActionResult GetArtworks(int id)
        {
            var text = _repo.Read(id);

            return Ok(text);
        }

        [HttpPost]
        public IHttpActionResult PostArtwork(Artwork aw)
        {
            var text = _repo.Create(aw);
            return Ok(aw);
        }

        [HttpPut]
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