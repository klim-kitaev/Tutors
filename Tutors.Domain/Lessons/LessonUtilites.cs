using System;
using System.Collections.Generic;
using System.Text;

namespace Tutors.Domain
{
    public static class LessonUtilites
    {
        public static TimeSpan GetFinishTime(TimeSpan startTime, LessonDuration lessonsDuration)
        {
            switch (lessonsDuration)
            {
                case LessonDuration.OneHour:
                    return startTime.Add(new TimeSpan(1, 0, 0));
                case LessonDuration.OneAndHalf:
                    return startTime.Add(new TimeSpan(1, 30, 0));
                case LessonDuration.TwoHour:
                    return startTime.Add(new TimeSpan(2, 0, 0));
                default:
                    throw new ArgumentException();
            }
        }

        public static DateTime GetFinishDateTime(DateTime startTime, LessonDuration lessonsDuration)
        {
            return startTime.Date + GetFinishTime(startTime.TimeOfDay, lessonsDuration);
        }
    }
}
