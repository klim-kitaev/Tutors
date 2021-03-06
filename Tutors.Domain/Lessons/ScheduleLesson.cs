﻿using System;
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
        /// Время начала занятий
        /// </summary>
        public TimeSpan LessonTime { get; set; }
        /// <summary>
        /// Продолжительность занятий
        /// </summary>
        public LessonDuration LessonsDuration { get; set; }

        /// <summary>
        /// Время окончания занятий
        /// </summary>
        public TimeSpan LessonFinishTime
        {
            get
            {
                return LessonUtilites.GetFinishTime(LessonTime, LessonsDuration);
            }
        }

    }
}
