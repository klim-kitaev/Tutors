using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutors.Dao.Abstract;
using Tutors.Domain;
using Tutors.Service.Domain.Abstract;

namespace Tutors.Service.Domain.Concrete
{
    public class LessonDomainService : ILessonDomainService
    {
        private readonly IPupilDao _pupilDao;
        private readonly ISheduleService _sheduleService;

        public LessonDomainService(IPupilDao pupilDao, ISheduleService sheduleService)
        {
            _pupilDao = pupilDao ?? throw new ArgumentNullException(nameof(pupilDao));
            _sheduleService = sheduleService ?? throw new ArgumentNullException(nameof(sheduleService));
        }


        /// <summary>
        /// Список занятий на данный диапазон дат
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public async Task<List<Lesson>> GetLessons(DateTime startDate, DateTime endDate, int userId)
        {
            var allPupils = await _pupilDao.GetPupils(userId);
            var lessons = new List<Lesson>();
            foreach (var pupil in allPupils)
            {
                lessons.AddRange(_sheduleService.GetLessons(pupil, startDate, endDate));
            }

            return lessons;
        }


        /// <summary>
        /// Добавление дополнительного урока
        /// </summary>
        /// <param name="pupilId"></param>
        /// <param name="extraLesson"></param>
        /// <returns></returns>
        public async Task<Pupil> AddExtraLesson(int pupilId, ExtraLesson extraLesson)
        {
            return await _pupilDao.AddExtraLesson(pupilId, extraLesson);
        }

        /// <summary>
        /// Удаление ругулярного урока у ученика
        /// </summary>
        /// <param name="pupilId"></param>
        /// <param name="canceledLesson"></param>
        /// <returns></returns>
        public async Task<Pupil> DeleteLesson(int pupilId, CanceledLesson canceledLesson)
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
        public async Task<Pupil> DeleteExtraLesson(int pupilId, int extraLessonId)
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
