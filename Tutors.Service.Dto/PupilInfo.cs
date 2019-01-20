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
        /// Список цен в зависимости от времени урока
        /// </summary>
        public Dictionary<int, Decimal> PriceList { get; set; }
        
    }
}
