using System;
using System.Collections.Generic;
using Tutors.Domain;
using Xunit;

namespace Tutors.Test
{
    public class SheduleTest
    {


        private readonly Pupil testPupil = new Pupil
        {
            Id = 1,
            FirstName = "Клим",
            LastName = "Китаев",
            UserId = 1,
            PriceList = new Dictionary<LessonDuration, decimal>
                {
                    {LessonDuration.OneHour,1200 },
                    {LessonDuration.OneAndHalf,1800 },
                    {LessonDuration.TwoHour,2400 }
                },
            PupilSchedule = new Schedule
            {
                Id = 1,
                ScheduleLessons = new List<ScheduleLesson>
                    {
                        new ScheduleLesson
                        {
                            LessonDay = DayOfWeek.Monday,
                            LessonsDuration = LessonDuration.OneHour,
                            LessonTime = new TimeSpan(18,0,0)
                        },
                        new ScheduleLesson
                        {
                            LessonDay = DayOfWeek.Wednesday,
                            LessonsDuration = LessonDuration.OneAndHalf,
                            LessonTime = new TimeSpan(17,30,0)
                        }
                    },
                ExtraLessons = new List<ExtraLesson>
                {
                    new ExtraLesson
                    {
                        Id = 1,
                        LessonsDateTime = new DateTime(2019,04,9,20,30,0),
                        LessonsDuration = LessonDuration.OneHour
                    },
                    new ExtraLesson
                    {
                        Id = 2,
                        LessonsDateTime = new DateTime(2019,04,16,20,30,0),
                        LessonsDuration = LessonDuration.OneHour
                    }
                },
                CanceledLessons = new List<CanceledLesson>
                {
                    new CanceledLesson
                    {
                        LessonDate = new DateTime(2019,04,15)
                    },
                     new CanceledLesson
                    {
                        LessonDate = new DateTime(2019,04,22)
                    }
                }
            }
        };
        public static object[][] testData = 
        {
            new object[]{new DateTime(2019, 04, 01), new DateTime(2019, 04, 03),2},
            new object[]{new DateTime(2019, 04, 01), new DateTime(2019, 04, 07),2},
            new object[]{new DateTime(2019, 04, 08), new DateTime(2019, 04, 14),3},
            new object[]{new DateTime(2019, 04, 15), new DateTime(2019, 04, 21),2},
            new object[]{new DateTime(2019, 04, 22), new DateTime(2019, 04, 28),1}
        };


        [Theory, MemberData(nameof(testData))]
        public void CheckLessonCounts(DateTime startDate,DateTime endDate, Decimal lessonCount)
        {
            //Arange
            var sheduleService = new Service.Domain.Concrete.SheduleService();

            //Act
            var lessons = sheduleService.GetLessons(testPupil, startDate, endDate);

            //Assert
            Assert.Equal(lessonCount, lessons.Count);
        }
    }
}
