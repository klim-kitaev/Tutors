using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tutors.Domain;

namespace Tutors.Service.Domain.Abstract
{
    /// <summary>
    /// Сервис работы с расписанием занятий
    /// </summary>
    public interface ILessonDomainService
    {
        /// <summary>
        /// Список занятий на данный диапазон дат
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        Task<List<Lesson>> GetLessons(DateTime startDate, DateTime endDate, int userId);


        /// <summary>
        /// Добавление дополнительного урока
        /// </summary>
        /// <param name="pupilId"></param>
        /// <param name="extraLesson"></param>
        /// <returns></returns>
        Task<Pupil> AddExtraLesson(int pupilId, ExtraLesson extraLesson);

        /// <summary>
        /// Удаление ругулярного урока у ученика
        /// </summary>
        /// <param name="pupilId"></param>
        /// <param name="canceledLesson"></param>
        /// <returns></returns>
        Task<Pupil> DeleteLesson(int pupilId, CanceledLesson canceledLesson);

        /// <summary>
        /// Удаление дополнительного урока
        /// </summary>
        /// <param name="pupilId"></param>
        /// <param name="extraLessonId"></param>
        /// <returns></returns>
        Task<Pupil> DeleteExtraLesson(int pupilId, int extraLessonId);
    }
}
