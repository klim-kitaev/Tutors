using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutors.Dao.Abstract;
using Tutors.Domain;
using Tutors.Service.Abstract;
using Tutors.Service.Domain.Abstract;
using Tutors.Service.Dto;

namespace Tutors.Service.Concrete
{
    /// <summary>
    /// Реализация сервиса работы с расписанием занятий
    /// </summary>
    public class LessonService : ILessonService
    {
        private readonly ILessonDomainService _lessonDomainService;
        private readonly IMapper _mapper;

        public LessonService(ILessonDomainService lessonDomainService, IMapper mapper)
        {
            _lessonDomainService = lessonDomainService ?? throw new ArgumentNullException(nameof(lessonDomainService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Список занятий на данный диапазон дат
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public async Task<List<LessonInfo>> GetLessons(DateTime startDate, DateTime endDate, int userId)
        {
            var lessons = await _lessonDomainService.GetLessons(startDate, endDate, userId);
            return _mapper.Map<List<LessonInfo>>(lessons);
        }

        /// <summary>
        /// Сохранение изменений в уроках
        /// </summary>
        /// <param name="lessonInfo"></param>
        /// <returns></returns>
        public async Task ChangeLessons(ChangeLessonInfo lessonInfo)
        {

            var deletedInfo = lessonInfo.DeletedInfo;
            var insertedInfo = lessonInfo.InsertedInfo;

            if (deletedInfo != null)
            {
                switch ((LessonInfoType)deletedInfo.LessonType)
                {
                    case LessonInfoType.Planned:
                        var cancelLesson = new CanceledLesson
                        {
                            LessonDate = deletedInfo.LessonDate.Value
                        };
                        await _lessonDomainService.DeleteLesson(lessonInfo.PupilId, cancelLesson);
                        break;
                    case LessonInfoType.Added:
                        await _lessonDomainService.DeleteExtraLesson(lessonInfo.PupilId, deletedInfo.Id.Value);
                        break;
                }
            }
            if(insertedInfo != null)
            {
                var extraLesson = _mapper.Map<ExtraLesson>(insertedInfo);
                await _lessonDomainService.AddExtraLesson(lessonInfo.PupilId, extraLesson);
            }
        }

       
    }
}
