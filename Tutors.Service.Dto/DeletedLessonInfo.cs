using System;

namespace Tutors.Service.Dto
{
    /// <summary>
    /// Информация об отмененом уроке
    /// </summary>
    public class DeletedLessonInfo
    {
        /// <summary>
        /// Тип урока (по плану или добавленный)
        /// </summary>
        public int LessonType { get; set; }

        /// <summary>
        /// Id урока (только для лобавленных)
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// День занятий (для тех что по плану)
        /// </summary>
        public DateTime? LessonDate { get; set; }
    }
}
