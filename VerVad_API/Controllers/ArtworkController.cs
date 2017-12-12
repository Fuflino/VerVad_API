using DAL.Entities;
using DAL.Facade;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace VerVad_API.Controllers
{
    public class ArtworkController : ApiController
    {
        // GET: Artwork
        private ArtworkRepository _repo = (ArtworkRepository)new Facade().GetArtworkRepository();

        [HttpGet]
        [ResponseType(typeof(List<Artwork>))]
        [Route("GetTextsFromGlobalGoal/{id:int}")]
        public IHttpActionResult GetTextsFromGlobalGoal(int id)
        {
            var artworks = _repo.GetArtworksFromGlobalGoal(id);
            return Ok(artworks);
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