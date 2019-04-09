using System;
using System.Collections.Generic;
using System.Text;

namespace Tutors.Service.Dto
{
    /// <summary>
    /// График занятий ученирка
    /// </summary>
    public class Schedule
    {
        /// <summary>
        /// Список занятий по расписанию
        /// </summary>
        public List<ScheduleLesson> ScheduleLessons { get; set; }
    }
}
