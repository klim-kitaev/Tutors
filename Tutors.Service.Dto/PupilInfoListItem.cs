using System;
using System.Collections.Generic;
using System.Text;

namespace Tutors.Service.Dto
{
    /// <summary>
    /// Данные об ученике (в списке Учеников)
    /// </summary>
    public class PupilInfoListItem
    {
        public int Id { get; set; }
        /// <summary>
        /// Краткое имя ученика
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Время занятия в понедельник
        /// </summary>
        public string TimeInMonday { get; set; }
        /// <summary>
        /// Время занятия в вторник
        /// </summary>
        public string TimeInTuesday { get; set; }
        /// <summary>
        /// Время занятия в среду
        /// </summary>
        public string TimeInWednesday { get; set; }
        /// <summary>
        /// Время занятия в четверг
        /// </summary>
        public string TimeInThursday { get; set; }
        /// <summary>
        /// Время занятия в пятницу
        /// </summary>
        public string TimeInFirday { get; set; }
        /// <summary>
        /// Время занятия в субботу
        /// </summary>
        public string TimeInSaturday { get; set; }
        /// <summary>
        /// Время занятия в воскресенье
        /// </summary>
        public string TimeInSunday { get; set; }
    }
}
