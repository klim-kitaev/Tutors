using System;
using System.Collections.Generic;
using System.Text;

namespace Tutors.Service.Dto
{
    /// <summary>
    /// Данные о занятии
    /// </summary>
    public class LessonInfo
    {
        /// <summary>
        /// Дата начала занятия
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Дата начала занятия
        /// </summary>
        public string StartDateStr { get; set; }
        /// <summary>
        /// Дата конца занятия
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// Дата конца занятия
        /// </summary>
        public string EndDateStr { get; set; }
        /// <summary>
        /// Цена занятия
        /// </summary>
        public Decimal Price { get; set; }

        /// <summary>
        /// Id ученика
        /// </summary>
        public int PupilId { get; set; }

        /// <summary>
        /// Имя ученика
        /// </summary>
        public string PupilName { get; set; }

        /// <summary>
        /// Тип урока
        /// </summary>
        public LessonInfoType LessonInfoType { get; set; }

        /// <summary>
        /// Продолжительность занятий
        /// </summary>
        public int LessonDuration { get; set; }
    }
}
