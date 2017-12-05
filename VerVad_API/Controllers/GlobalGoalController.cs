﻿using DAL.Entities;
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
    public class GlobalGoalController : ApiController
    {
        private IRepository<GlobalGoal, int> _repo = new Facade().GetGlobalGoalRepository();
        private GlobalGoalHelper _helper = new GlobalGoalHelper();

        private bool GlobalGoalExists(int id, string language)
        {
            return _repo.Read(id) != null;
        }

        [HttpGet]
        [ResponseType(typeof(DTOGlobalGoal))]
        public IHttpActionResult GetGlobalGoal(int id, string language)
        {
            var globalGoal = _repo.Read(id);

            if (!GlobalGoalExists(id, language))
            {
                return NotFound();
            }

            var DTO = _helper.GetGlobalGoalDTO(language, globalGoal);

            return Ok(DTO);
        }

        [HttpGet]
        [ResponseType(typeof(List<DTOGlobalGoal>))]
        public IHttpActionResult GetGlobalGoals(string language)
        {
            var globalGoals = _repo.ReadAll();
            var DTOList = new List<DTOGlobalGoal>();

            foreach (var item in globalGoals)
            {
                var DTO = _helper.GetGlobalGoalDTO(language, item);
                DTOList.Add(DTO);
            }

            return Ok(DTOList);
        }

        [HttpGet]
        [ResponseType(typeof(List<GlobalGoal>))]
        public IHttpActionResult GetGlobalGoals()
        {
            var ggs = _repo.ReadAll();
            return Ok(ggs);
        }

        [HttpPost]
        [ResponseType(typeof(GlobalGoal))]
        public IHttpActionResult PostGlobalGoal(GlobalGoal gg)
        {
            var globalGoal = _repo.Create(gg);
            return Ok(globalGoal);
        }

        // Test method...    
        [HttpGet]
        public string ReturnDDL(string audioUrl)
        {
            return audioUrl = _helper.ConvertToDDL(audioUrl);
        }

    }
}
