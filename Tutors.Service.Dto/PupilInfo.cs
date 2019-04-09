using System;
using System.Collections.Generic;

namespace Tutors.Service.Dto
{
    /// <summary>
    /// Данные об ученике
    /// </summary>
    public class PupilInfo
    {
        public int Id { get; set; }
        /// <summary>
        /// Имя 
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Цена урока за час
        /// </summary>
        public Decimal? OneHourPrice { get; set; }
        /// <summary>
        /// Цена урока за полтора часа
        /// </summary>
        public Decimal? OneAndHalfPrice { get; set; }
        /// <summary>
        /// Цена урока за два часа
        /// </summary>
        public Decimal? TwoHourPrice { get; set; }

        /// <summary>
        /// Расписание занятий
        /// </summary>
        public Schedule PupilSchedule { get; set; }
    }
}
