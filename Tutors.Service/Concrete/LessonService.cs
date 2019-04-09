using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tutors.Dao.Abstract;
using Tutors.Service.Abstract;
using Tutors.Service.Dto;

namespace Tutors.Service.Concrete
{
    /// <summary>
    /// Реализация сервиса работы с расписанием занятий
    /// </summary>
    public class LessonService : ILessonService
    {
        private readonly IPupilDao _pupilDao;
        private readonly IMapper _mapper;
        private readonly ISheduleService _sheduleService;

        public LessonService(IPupilDao pupilDao, IMapper mapper, ISheduleService sheduleService)
        {
            _pupilDao = pupilDao ?? throw new ArgumentNullException(nameof(pupilDao));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _sheduleService = sheduleService ?? throw new ArgumentNullException(nameof(sheduleService));
        }

        /// <summary>
        /// Список занятий на данный диапазон дат
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public async Task<List<LessonInfo>> GetLessons(DateTime startDate, DateTime endDate, int userId)
        {
            var allPupils = await _pupilDao.GetPupils(userId);
            var lessons = new List<Domain.Lesson>();
            foreach (var pupil in allPupils)
            {
                lessons.AddRange(_sheduleService.GetLessons(pupil, startDate, endDate));
            }
            return _mapper.Map<List<LessonInfo>>(lessons);
        }
    }
}
