using System;
using System.Collections.Generic;
using System.Text;

namespace Tutors.Domain
{
    /// <summary>
    /// График занятий ученирка
    /// </summary>
    public class Schedule
    {
        public int Id { get; set; }
        /// <summary>
        /// Список занятий по расписанию
        /// </summary>
        public List<ScheduleLesson> ScheduleLessons { get; set; }
        /// <summary>
        /// Дополнительные уроки
        /// </summary>
        public List<ExtraLesson> ExtraLessons { get; set; }
        /// <summary>
        /// Отмененные уроки
        /// </summary>
        public List<CanceledLesson> CanceledLessons { get; set; }

        public Schedule()
        {
            ScheduleLessons = new List<ScheduleLesson>();
            ExtraLessons = new List<ExtraLesson>();
            CanceledLessons = new List<CanceledLesson>();
        }
    }
}
