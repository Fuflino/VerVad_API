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

        [HttpGet] //DTO
        [ResponseType(typeof(DTOAudioVideo))]
        public IHttpActionResult GetAudioVideo(int id, string language)
        {
            var audioVideo = _repo.Read(id);

            if (audioVideo == null)
            {
                return NotFound();
            }

            var DTO = _helper.GetAudioVideoDTO(language, audioVideo);

            return Ok(DTO);
        }

        [HttpGet] //DTO
        [ResponseType(typeof(List<DTOAudioVideo>))]
        public IHttpActionResult GetAudioVideos(string language)
        {
            var audioVideo = _repo.ReadAll();
            if (audioVideo == null)
            {
                return NotFound();
            }

            var DTOList = new List<DTOAudioVideo>();

            foreach (var item in audioVideo)
            {
                var DTO = _helper.GetAudioVideoDTO(language, item);
                DTOList.Add(DTO);
            }

            return Ok(DTOList);
        }

        [HttpGet]
        public IHttpActionResult GetAudioVideo(int id)
        {
            var audioVideo = _repo.Read(id);

            if (audioVideo == null)
            {
                return NotFound();
            }

            return Ok(audioVideo);
        }

        [HttpGet]
        [ResponseType(typeof(List<AudioVideo>))]
        public IHttpActionResult GetAudioVideos()
        {
            var audioVideos = _repo.ReadAll();
            if (audioVideos == null)
            {
                return NotFound();
            }
            return Ok(audioVideos);
        }

        [HttpPost]
        [ResponseType(typeof(AudioVideo))]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult PostAudioVideo(AudioVideo la)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var audioVideo = _repo.Create(la);
            return Ok(audioVideo);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult PutAudioVideo(AudioVideo la)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var audioVideo = _repo.Update(la);
            return Ok(audioVideo);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult DeleteAudioVideo(int id)
        {
            var audioVideo = _repo.Delete(id);

            if (audioVideo == false)
            {
                return NotFound();
            }
            
            return Ok();
        }
    }
}
