using System;
using System.Collections.Generic;
using System.Text;

namespace Tutors.Service.Dto
{
    /// <summary>
    /// Данные о занятии по расписанию
    /// </summary>
    public class ScheduleLesson
    {
        /// <summary>
        /// День занятий
        /// </summary>
        public int LessonDay { get; set; }
        /// <summary>
        /// Время начала занятий
        /// </summary>
        public TimeSpan LessonTime { get; set; }
        /// <summary>
        /// Продолжительность занятий
        /// </summary>
        public int LessonsDuration { get; set; }
    }
}
