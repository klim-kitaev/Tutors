using System;
using System.Collections.Generic;
using System.Text;

namespace Tutors.Domain
{
    /// <summary>
    /// Данные о занятии по расписанию
    /// </summary>
    public class ScheduleLesson
    {
        /// <summary>
        /// День занятий
        /// </summary>
        public DayOfWeek LessonDay { get; set; }
        /// <summary>
        /// Дата занятий
        /// </summary>
        public TimeSpan LessonTime { get; set; }
        /// <summary>
        /// Продолжительность занятий
        /// </summary>
        public LessonsDuration LessonsDuration { get; set; }

    }
}
