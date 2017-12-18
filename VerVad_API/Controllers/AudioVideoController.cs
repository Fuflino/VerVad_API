using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DAL.Entities;
using DAL.Facade;
using DAL.Interfaces;
using VerVad_API.Helpers;
using VerVad_API.Models;
using DAL.Repositories;

namespace VerVad_API.Controllers
{
    [RoutePrefix("api/AudioVideo")]

    public class AudioVideoController : ApiController
    {
        private GlobalGoalChildrensHelper _helper = new GlobalGoalChildrensHelper();
        private AudioVideoRepository _repo = (AudioVideoRepository)new Facade().GetAudioVideoRepository();

        private bool AudioVideoExists(int id, string language)
        {
            return _repo.Read(id) != null;
        }

        [HttpGet] //DTO
        [ResponseType(typeof(DTOAudioVideo))]
        public IHttpActionResult GetAudioVideo(int id, string language)
        {
            var audioVideo = _repo.Read(id);

            if (!AudioVideoExists(id, language))
            {
                return NotFound();
            }

            var DTO = _helper.GetAudioVideoDTO(language, audioVideo);

            return Ok(DTO);
        }

        [HttpGet]
        public IHttpActionResult GetAudioVideo(int id)
        {
            var audioVideo = _repo.Read(id);

            if (!AudioVideoExists(id, "da"))
            {
                return NotFound();
            }

            return Ok(audioVideo);
        }

        [HttpGet] //DTO
        [ResponseType(typeof(List<DTOAudioVideo>))]
        public IHttpActionResult GetAudioVideos(string language)
        {
            var audioVideo = _repo.ReadAll();
            var DTOList = new List<DTOAudioVideo>();

            foreach (var item in audioVideo)
            {
                var DTO = _helper.GetAudioVideoDTO(language, item);
                DTOList.Add(DTO);
            }

            return Ok(DTOList);
        }

        [HttpGet]
        [ResponseType(typeof(List<AudioVideo>))]
        public IHttpActionResult GetAudioVideos()
        {
            var ggs = _repo.ReadAll();
            return Ok(ggs);
        }

        [HttpPost]
        [ResponseType(typeof(AudioVideo))]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult PostAudioVideo(AudioVideo la)
        {
            var audioVideo = _repo.Create(la);
            return Ok(audioVideo);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult PutAudioVideo(AudioVideo la)
        {
            var audioVideo = _repo.Update(la);
            return Ok(audioVideo);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult DeleteAudioVideo(int id)
        {

            _repo.Delete(id);
            return Ok();
        }
    }
}
