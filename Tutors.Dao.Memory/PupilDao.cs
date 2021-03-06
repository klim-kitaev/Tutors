﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutors.Dao.Abstract;
using Tutors.Domain;

namespace Tutors.Dao.Memory
{
    /// <summary>
    /// Реализация DAO работы с учениками (хранение в памяти)
    /// </summary>
    public class PupilDao : IPupilDao
    {

        private static List<Pupil> _pupils = new List<Pupil>
        {
            new Pupil
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
                    }
                }
            }
        };

        /// <summary>
        /// Удаление ученика
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Pupil> DeletePupil(int id)
        {
            var pupil = _pupils.Where(p => p.Id == id).FirstOrDefault();
            if(pupil != null)
            {
                _pupils.Remove(pupil);
            }
            return Task.FromResult<Pupil>(pupil);
        }

        /// <summary>
        /// Получение данных о конкретном ученике
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Pupil> GetPupil(int id)
        {
            var pupil = _pupils.Where(p => p.Id == id).FirstOrDefault();
            return Task.FromResult<Pupil>(pupil);
        }

        /// <summary>
        /// Получение списка учеников пользователя
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Task<List<Pupil>> GetPupils(int userId)
        {
            var pupils = _pupils.Where(p => p.UserId == userId).ToList();
            return Task.FromResult<List<Pupil>>(pupils);
        }

        /// <summary>
        /// Сохранение / обновление данных об ученике
        /// </summary>
        /// <param name="pupil"></param>
        /// <returns></returns>
        public Task<Pupil> SavePupil(Pupil pupil)
        {
            if(pupil.Id == 0)
            {
                pupil.Id = GeneratePupilId();
                _pupils.Add(pupil);
            }
            else
            {
                int index = _pupils.FindIndex(p => p.Id == pupil.Id);
                if(index >= 0)
                {
                    _pupils[index] = pupil;
                }
            }
            return Task.FromResult<Pupil>(pupil);
        }

        private int GeneratePupilId()
        {
            int maxId = _pupils.Select(p => p.Id).Max();
            return maxId + 1;
        }

        private int GenerateExraLessonId()
        {
            int maxId = _pupils.SelectMany(p => p.PupilSchedule.ExtraLessons.Select(x => x.Id)).DefaultIfEmpty(0).Max();
            return maxId + 1;
        }

        /// <summary>
        /// Добавление дополнительного урока
        /// </summary>
        /// <param name="pupilId"></param>
        /// <param name="extraLesson"></param>
        /// <returns></returns>
        public async Task<Pupil> AddExtraLesson(int pupilId, ExtraLesson extraLesson)
        {
            var pupil = await GetPupil(pupilId);
            if(pupil == null)
            {
                throw new ArgumentException("Pupil not found");
            }
            extraLesson.Id = GenerateExraLessonId();
            pupil.PupilSchedule.ExtraLessons.Add(extraLesson);
            return await SavePupil(pupil);
        }
    }
}
