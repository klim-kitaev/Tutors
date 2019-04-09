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
    public class LessonsController : ControllerBase
    {
        private readonly int userId = 1;
        private readonly ILessonService _lessonService;

        public LessonsController(ILessonService lessonService)
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
            return await _lessonService.GetLessons(startDate, endDate, userId);
        }


        public async Task<ActionResult> ChangeLessons(ChangeLessonInfo lessonInfo)
        {
            return await Task.FromResult<AcceptedResult>(null);
        }
    }
}