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
    }
}
