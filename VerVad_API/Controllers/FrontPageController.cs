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
using System.Web.Http.Cors;

namespace VerVad_API.Controllers
{
    [RoutePrefix("api/FrontPage")]

    public class FrontPageController : ApiController
    {
        private readonly IFrontPageRepository<FrontPage, int> _repo = new Facade().GetFrontPageRepository();
        private readonly FrontPageHelper _helper = new FrontPageHelper();

        private bool FrontPageExists(int id, string language)
        {
            return _repo.Read(id) != null;
        }

        [HttpGet] //DTO
        [ResponseType(typeof(DTOFrontPage))]
        public IHttpActionResult GetFrontPage(int id, string language)
        {
            var frontPage = _repo.Read(id);

            if (!FrontPageExists(id, language))
            {
                return NotFound();
            }

            var DTO = _helper.GetFrontPageDTO(language, frontPage);

            return Ok(DTO);
        }

        [HttpGet]
        [ResponseType(typeof(FrontPage))]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult GetFrontPage(int id)
        {
            var frontPage = _repo.Read(id);

            if (!FrontPageExists(id, "da"))
            {
                return NotFound();
            }

            return Ok(frontPage);
        }

        [HttpPut]
        [ResponseType(typeof(void))]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult PutFrontPage(FrontPage frontPage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repo.Update(frontPage);

            return StatusCode(HttpStatusCode.NoContent);
        }

    }
}
