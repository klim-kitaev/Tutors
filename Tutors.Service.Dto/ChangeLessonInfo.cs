using System.Collections.Generic;
using System.Text;

namespace Tutors.Service.Dto
{
    /// <summary>
    /// Информация об изменном уроке
    /// </summary>
    public class ChangeLessonInfo
    {
        /// <summary>
        /// Id ученика
        /// </summary>
        public int PupilId { get; set; }

        /// <summary>
        /// Иформация об добавленном уроке
        /// </summary>
        public InsertedLessonInfo InsertedInfo { get; set; }

        /// <summary>
        /// Информация об отмененом уроке
        /// </summary>
        public DeletedLessonInfo DeletedInfo { get; set; }
    }
}
