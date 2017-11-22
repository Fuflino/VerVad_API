﻿using DAL.Entities;
using DAL.Interfaces;
using DAL.Contexts;
using DAL.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using VerVad_API.Models;
using VerVad_API.Helpers;

namespace VerVad_API.Controllers
{
    public class FrontPageController : ApiController
    {
        private IFrontPageRepository<FrontPage, int, string> frontPageRepository = new Facade().GetFrontPageRepository();
        private FrontPageHelper helper = new FrontPageHelper();

        [HttpGet]
        [ResponseType(typeof(FrontPage))]
        public IHttpActionResult GetFrontPage(int id, string language)
        {
            var frontPage = frontPageRepository.Read(id, language);

            if (!FrontPageExists(id, language))
            {
                return NotFound();
            }
            

            var dTO = new DTOFrontPage()
            {
                Id = frontPage.Id,
                Title = helper.GetTitle(language, frontPage),
                Description = helper.GetDescription(language, frontPage),
                ImgUrl = frontPage.ImgURL
            };

            return Ok(dTO);
        }

        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFrontPage(int id, FrontPage frontPage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            frontPageRepository.Update(frontPage);

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPost]
        [ResponseType(typeof(FrontPage))]
        public IHttpActionResult PostFrontPage(FrontPage frontPage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            frontPageRepository.Create(frontPage);

            return CreatedAtRoute("DefaultApi", new { id = frontPage.Id }, frontPage);
        }

        [HttpDelete]
        [ResponseType(typeof(FrontPage))]
        public IHttpActionResult DeleteFrontPage(int id, string language)
        {
            if (!FrontPageExists(id, language))
            {
                return NotFound();
            }

            frontPageRepository.Delete(id);

            return Ok();
        }

        private bool FrontPageExists(int id, string language)
        {
            return frontPageRepository.Read(id, language) != null;
        }


    }
}
