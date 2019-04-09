using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tutors.Service.Dto;

namespace Tutors.Service.Abstract
{
    /// <summary>
    /// Сервис работы с расписанием занятий
    /// </summary>
    public interface ILessonService
    {
        /// <summary>
        /// Список занятий на данный диапазон дат
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        Task<List<LessonInfo>> GetLessons(DateTime startDate, DateTime endDate, int userId);
    }
}
