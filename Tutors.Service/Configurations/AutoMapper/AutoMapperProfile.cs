﻿using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Dto = Tutors.Service.Dto;
using Domain = Tutors.Domain;
using System.Linq;
using Tutors.Domain;

namespace Tutors.Service.Configurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Pupil, Dto.PupilInfo>()
                .ForMember(o => o.OneHourPrice, m => m.MapFrom(s => _GetLessonPrice(s.PriceList, LessonDuration.OneHour)))
                .ForMember(o => o.OneAndHalfPrice, m => m.MapFrom(s => _GetLessonPrice(s.PriceList, LessonDuration.OneAndHalf)))
                .ForMember(o => o.TwoHourPrice, m => m.MapFrom(s => _GetLessonPrice(s.PriceList, LessonDuration.TwoHour)));
            CreateMap<Dto.PupilInfo, Pupil>();

            CreateMap<Pupil, Dto.PupilInfoListItem>()
                .ForMember(o => o.Name, m => m.MapFrom(s => $"{s.FirstName} {s.LastName}".Trim()))
                .ForMember(o => o.TimeInMonday, m => m.MapFrom(s => _GetTimeInDay(s.PupilSchedule, DayOfWeek.Monday)))
                .ForMember(o => o.TimeInTuesday, m => m.MapFrom(s => _GetTimeInDay(s.PupilSchedule, DayOfWeek.Tuesday)))
                .ForMember(o => o.TimeInWednesday, m => m.MapFrom(s => _GetTimeInDay(s.PupilSchedule, DayOfWeek.Wednesday)))
                .ForMember(o => o.TimeInThursday, m => m.MapFrom(s => _GetTimeInDay(s.PupilSchedule, DayOfWeek.Thursday)))
                .ForMember(o => o.TimeInFirday, m => m.MapFrom(s => _GetTimeInDay(s.PupilSchedule, DayOfWeek.Friday)))
                .ForMember(o => o.TimeInSaturday, m => m.MapFrom(s => _GetTimeInDay(s.PupilSchedule, DayOfWeek.Saturday)))
                .ForMember(o => o.TimeInSunday, m => m.MapFrom(s => _GetTimeInDay(s.PupilSchedule, DayOfWeek.Sunday)));

            CreateMap<Schedule, Dto.Schedule>().ReverseMap();
            CreateMap<ScheduleLesson, Dto.ScheduleLesson>().ReverseMap();

            CreateMap<Lesson, Dto.LessonInfo>()
                .ForMember(o => o.StartDate, m => m.MapFrom(s => s.LessonsDateTime))
                .ForMember(o => o.StartDateStr, m => m.MapFrom(s => s.LessonsDateTime.ToString("dd.MM.yyyy HH:mm:ss")))
                .ForMember(o => o.EndDate, m => m.MapFrom(s => s.LessonsFinishDateTime))
                .ForMember(o => o.EndDateStr, m => m.MapFrom(s => s.LessonsFinishDateTime.ToString("dd.MM.yyyy HH:mm:ss")))                
                .ForMember(o=>o.LessonDuration,m=>m.MapFrom(s=>(int)s.LessonsDuration))
                .ForMember(o => o.PupilName, m => m.MapFrom(s => $"{s.Pupil.FirstName} {s.Pupil.LastName}".Trim()));


            CreateMap<Dto.InsertedLessonInfo, ExtraLesson>()
                .ForMember(o => o.LessonsDuration, m => m.MapFrom(s => (LessonDuration)s.LessonsDuration));

        }


        private Decimal? _GetLessonPrice(Dictionary<LessonDuration, Decimal> priceList, LessonDuration lessonsDuration)
        {
            if (priceList.TryGetValue(lessonsDuration, out Decimal value))
                return value;
            return null;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="schedule"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        private string _GetTimeInDay(Schedule schedule, DayOfWeek dayOfWeek)
        {
            var lesson = schedule.ScheduleLessons.Where(p => p.LessonDay == dayOfWeek).FirstOrDefault();
            if (lesson == null)
                return string.Empty;

            return $"{lesson.LessonTime.ToString(@"hh\:mm")} - {lesson.LessonFinishTime.ToString(@"hh\:mm")}";

        }
    }
}
