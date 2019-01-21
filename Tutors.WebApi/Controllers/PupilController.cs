﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tutors.Service.Abstract;
using Tutors.Service.Dto;

namespace Tutors.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PupilController : ControllerBase
    {
        private readonly IPupilService _pupilService;
        private readonly int userId = 1;

        public PupilController(IPupilService pupilService)
        {
            _pupilService = pupilService ?? throw new ArgumentNullException(nameof(pupilService));
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<PupilInfoListItem>>> Get()
        {
            return await _pupilService.GetPupils(userId);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<PupilInfo>> Get(int id)
        {
            if (id == 0)
                return BadRequest();

            return await _pupilService.GetPupilInfo(id, userId);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<PupilInfo>>Save(PupilInfo pupil)
        {
            if (pupil == null)
                return BadRequest();

            return await _pupilService.SavePupilInfo(pupil, userId);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<PupilInfo>>Delete(int id)
        {
            if (id == 0)
                return BadRequest();

            return await _pupilService.DeletePupilInfo(id, userId);
        }

    }
}