using System;
using System.Collections.Generic;
using System.Text;

namespace Tutors.Domain
{
    /// <summary>
    /// Дополнительное занятие
    /// </summary>
    public class ExtraLesson
    {
        /// <summary>
        /// Дата и время начала занятий
        /// </summary>
        public DateTime LessonsDateTime { get; set; }
        /// <summary>
        /// Продолжительность занятий
        /// </summary>
        public LessonsDuration LessonsDuration { get; set; }
    }
}
