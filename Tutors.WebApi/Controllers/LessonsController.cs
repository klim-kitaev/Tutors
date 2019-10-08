using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tutors.Service.Abstract;
using Tutors.Service.Dto;

namespace Tutors.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonsController : BaseController
    {
        private readonly ILessonService _lessonService;

        public LessonsController(ILessonService lessonService, ILogger<PupilController> log) : base(log)
        {
            _lessonService = lessonService ?? throw new ArgumentNullException(nameof(lessonService));
        }



        /// <summary>
        /// Список занятий на данный диапазон дат
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<LessonInfo>>>Get(DateTime startDate, DateTime endDate)
        {
            int userId = GetUserId();
            return await _lessonService.GetLessons(startDate, endDate, userId);
        }

        /// <summary>
        /// Сохранение изменений в уроках
        /// </summary>
        /// <param name="lessonInfo"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<ActionResult> ChangeLessons(ChangeLessonInfo lessonInfo)
        {
            int userId = GetUserId();
            if(userId >0)
            {
                await _lessonService.ChangeLessons(lessonInfo);
            }           
            return Ok();
        }
    }
}