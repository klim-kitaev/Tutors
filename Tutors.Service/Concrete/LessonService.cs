using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
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

        /// <summary>
        /// Сохранение изменений в уроках
        /// </summary>
        /// <param name="lessonInfo"></param>
        /// <returns></returns>
        public async Task ChangeLessons(ChangeLessonInfo lessonInfo)
        {
            var pupil = await _pupilDao.GetPupil(lessonInfo.PupilId);
            if(pupil == null)
            {
                throw new ArgumentException("Pupil not found");
            }

            var deletedInfo = lessonInfo.DeletedInfo;
            var insertedInfo = lessonInfo.InsertedInfo;

            if (deletedInfo != null)
            {
                switch ((Domain.LessonInfoType)deletedInfo.LessonType)
                {
                    case Domain.LessonInfoType.Planned:
                        var cancelLesson = new Domain.CanceledLesson
                        {
                            LessonDate = deletedInfo.LessonDate.Value
                        };
                        await DeleteLesson(lessonInfo.PupilId, cancelLesson);
                        break;
                    case Domain.LessonInfoType.Added:
                        await DeleteExtraLesson(lessonInfo.PupilId, deletedInfo.Id.Value);
                        break;
                }
            }
            if(insertedInfo != null)
            {
                var extraLesson = _mapper.Map<Domain.ExtraLesson>(insertedInfo);
                await _pupilDao.AddExtraLesson(lessonInfo.PupilId, extraLesson);
            }
        }

        /// <summary>
        /// Удаление ругулярного урока у ученика
        /// </summary>
        /// <param name="pupilId"></param>
        /// <param name="canceledLesson"></param>
        /// <returns></returns>
        private async Task<Domain.Pupil> DeleteLesson(int pupilId, Domain.CanceledLesson canceledLesson)
        {
            var pupil = await _pupilDao.GetPupil(pupilId);
            if (pupil == null)
            {
                throw new ArgumentException("Pupil not found");
            }
            if (pupil.PupilSchedule.CanceledLessons.Where(p => p == canceledLesson).Count() == 0)
            {
                pupil.PupilSchedule.CanceledLessons.Add(canceledLesson);
            }
            return await _pupilDao.SavePupil(pupil);
        }

        /// <summary>
        /// Удаление дополнительного урока
        /// </summary>
        /// <param name="pupilId"></param>
        /// <param name="extraLessonId"></param>
        /// <returns></returns>
        private async Task<Domain.Pupil> DeleteExtraLesson(int pupilId, int extraLessonId)
        {
            var pupil = await _pupilDao.GetPupil(pupilId);
            if (pupil == null)
            {
                throw new ArgumentException("Pupil not found");
            }

            var extraLesson = pupil.PupilSchedule.ExtraLessons.Where(p => p.Id == extraLessonId).FirstOrDefault();

            if (extraLesson != null)
            {
                pupil.PupilSchedule.ExtraLessons.Remove(extraLesson);
            }

            return await _pupilDao.SavePupil(pupil);
        }


    }
}
