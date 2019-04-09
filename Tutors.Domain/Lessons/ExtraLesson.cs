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
        /// Id добавленного урока
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Дата и время начала занятий
        /// </summary>
        public DateTime LessonsDateTime { get; set; }
        /// <summary>
        /// Продолжительность занятий
        /// </summary>
        public LessonDuration LessonsDuration { get; set; }
    }
}
