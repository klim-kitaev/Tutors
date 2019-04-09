using System;

namespace Tutors.Service.Dto
{
    /// <summary>
    /// Иформация об добавленном уроке
    /// </summary>
    public class InsertedLessonInfo
    {
        /// <summary>
        /// Дата и время начала занятий
        /// </summary>
        public DateTime LessonsDateTime { get; set; }
        /// <summary>
        /// Продолжительность занятий
        /// </summary>
        public int LessonsDuration { get; set; }
    }
}
