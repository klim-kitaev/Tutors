using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutors.Domain;
using Tutors.Service.Abstract;

namespace Tutors.Service.Concrete
{
    /// <summary>
    /// Сервис работы с расписанием
    /// </summary>
    public class SheduleService : ISheduleService
    {
        /// <summary>
        /// Получить список уроков ученика за определенный период
        /// </summary>
        /// <param name="pupil"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public  List<Lesson> GetLessons(Pupil pupil, DateTime startDate, DateTime endDate)
        {
            var lessons = GetSheduleLessons(pupil, startDate, endDate);
            return lessons;
        }

        /// <summary>
        /// Генерация списка регулярных уроков
        /// </summary>
        /// <param name="pupil"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        private List<Lesson> GetSheduleLessons(Pupil pupil, DateTime startDate, DateTime endDate)
        {
            var lessons = new List<Lesson>();

            for (var dt = startDate.Date; dt <= endDate.Date; dt=dt.AddDays(1))
            {
                var sheduleLessons = pupil.PupilSchedule.ScheduleLessons.Where(p => p.LessonDay == dt.DayOfWeek).ToList();
                foreach (var slesson in sheduleLessons)
                {
                    lessons.Add(new Lesson
                    {
                        LessonsDateTime = dt.Add(slesson.LessonTime),
                        LessonsDuration = slesson.LessonsDuration,
                        Pupil = pupil,
                        Price = pupil.PriceList.Where(p => p.Key == slesson.LessonsDuration).First().Value
                    });
                }
            }
            return lessons;
        }
    }
}
