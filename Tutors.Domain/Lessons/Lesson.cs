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
        public LessonsDuration LessonsDuration { get; set; }
        /// <summary>
        /// Цена занятия
        /// </summary>
        public Decimal Price { get; set; }
    }
}
