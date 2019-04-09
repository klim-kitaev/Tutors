using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tutors.Domain;

namespace Tutors.Service.Abstract
{
    /// <summary>
    /// Интерфейс сервиса работы с расписанием
    /// </summary>
    public interface ISheduleService
    {
        /// <summary>
        /// Получить список уроков ученика за определенный период
        /// </summary>
        /// <param name="pupil"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        List<Lesson> GetLessons(Pupil pupil, DateTime startDate, DateTime endDate);
    }
}
