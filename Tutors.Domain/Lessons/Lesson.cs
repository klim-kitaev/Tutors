using System;
using System.Collections.Generic;
using System.Text;

namespace Tutors.Domain
{
    /// <summary>
    /// Данные о занятии
    /// </summary>
    public class Lesson
    {
        /// <summary>
        /// Дата и время начала занятий
        /// </summary>
        public DateTime LessonsDateTime { get; set; }
        /// <summary>
        /// Продолжительность занятий
        /// </summary>
        public LessonDuration LessonsDuration { get; set; }
        /// <summary>
        /// Цена занятия
        /// </summary>
        public Decimal Price { get; set; }

        /// <summary>
        /// Информация об ученике
        /// </summary>
        public Pupil Pupil { get; set; }

        /// <summary>
        /// Дата и время начала занятий
        /// </summary>
        public DateTime LessonsFinishDateTime
        {
            get
            {
                return LessonUtilites.GetFinishDateTime(LessonsDateTime, LessonsDuration);
            }
        }

    }
}
