using System;
using System.Collections.Generic;

namespace Tutors.Domain
{
    /// <summary>
    /// Данные об ученике
    /// </summary>
    public class Pupil
    {
        public int Id { get; set; }
        /// <summary>
        /// Имя 
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Список цен в зависимости от времени урока
        /// </summary>
        public Dictionary<LessonsDuration, Decimal> PriceList { get; set; }
        /// <summary>
        /// Расписание занятий
        /// </summary>
        public Schedule PupilSchedule { get; set; }
        /// <summary>
        /// Пользователь
        /// </summary>
        public int UserId { get; set; }
    }
}
