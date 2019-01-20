using System;
using System.Collections.Generic;
using System.Text;

namespace Tutors.Domain
{
    /// <summary>
    /// Данные об отмененном занятии
    /// </summary>
    public class CanceledLesson
    {
        /// <summary>
        /// День занятий
        /// </summary>
        public DateTime LessonDate { get; set; }
    }
}
