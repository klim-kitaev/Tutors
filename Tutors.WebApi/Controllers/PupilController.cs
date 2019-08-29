using System;
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
    public class PupilController : BaseController
    {
        private readonly IPupilService _pupilService;

        public PupilController(IPupilService pupilService)
        {
            _pupilService = pupilService ?? throw new ArgumentNullException(nameof(pupilService));
        }        

        /// <summary>
        /// Получить список учеников
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<PupilInfoListItem>>> Get()
        {
            int userId = GetUserId();
            return await _pupilService.GetPupils(userId);
        }

        /// <summary>
        /// Получить данные по ученику
        /// </summary>
        /// <param name="id">id ученика</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<PupilInfo>> Get(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
                

            int userId = GetUserId();

            return await _pupilService.GetPupilInfo(id, userId);
        }

        /// <summary>
        /// Сохранить / обновить данные об ученике
        /// </summary>
        /// <param name="pupil">данные об ученике</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<PupilInfo>>Save(PupilInfo pupil)
        {
            if (pupil == null)
            {
                return BadRequest();
            }
                

            int userId = GetUserId();
            if(userId == 0)
            {
                return pupil;
            }

            return await _pupilService.SavePupilInfo(pupil, userId);
        }

        /// <summary>
        /// Удалить ученика
        /// </summary>
        /// <param name="id">id ученика</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<PupilInfo>>Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
                

            int userId = GetUserId();
            if (userId == 0)
            {
                return BadRequest();
            }

            return await _pupilService.DeletePupilInfo(id, userId);
        }

    }
}