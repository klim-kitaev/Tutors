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
            lessons.AddRange(GetExtraLessons(pupil, startDate, endDate));
            return lessons.OrderBy(p=>p.LessonsDateTime).ToList();
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
            var canceledLessons = pupil.PupilSchedule.CanceledLessons;

            for (var dt = startDate.Date; dt <= endDate.Date; dt=dt.AddDays(1))
            {
                var sheduleLessons = pupil.PupilSchedule.ScheduleLessons.Where(p => p.LessonDay == dt.DayOfWeek).ToList();
                foreach (var slesson in sheduleLessons)
                {
                    var lesson = new Lesson
                    {
                        LessonsDateTime = dt.Add(slesson.LessonTime),
                        LessonsDuration = slesson.LessonsDuration,
                        Pupil = pupil,
                        Price = pupil.PriceList.Where(p => p.Key == slesson.LessonsDuration).First().Value,
                        LessonInfoType = LessonInfoType.Planned
                    };
                    if(!IsLessonCanceled(lesson,canceledLessons))
                    lessons.Add(lesson);
                }
            }
            return lessons;
        }

        /// <summary>
        /// ПОлучение списка дополнительных уроков
        /// </summary>
        /// <param name="pupil"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        private List<Lesson> GetExtraLessons(Pupil pupil, DateTime startDate, DateTime endDate)
        {
            return  pupil.PupilSchedule.ExtraLessons
                .Where(p => p.LessonsDateTime > startDate && p.LessonsDateTime.AddDays(1) < endDate)
                .Select(p => new Lesson
                {
                    LessonsDateTime = p.LessonsDateTime,
                    LessonsDuration = p.LessonsDuration,
                    Pupil = pupil,
                    Price = pupil.PriceList.Where(x => x.Key == p.LessonsDuration).First().Value,
                    Id = p.Id,
                    LessonInfoType = LessonInfoType.Added
                }).ToList();
        }

        /// <summary>
        /// Проверка не отменен ли урок
        /// </summary>
        /// <param name="lesson"></param>
        /// <param name="canceledLessons"></param>
        /// <returns></returns>
        private bool IsLessonCanceled(Lesson lesson, IEnumerable<CanceledLesson> canceledLessons)
        {
            return canceledLessons.Contains(new CanceledLesson { LessonDate = lesson.LessonsDateTime });
        }
    }
}
