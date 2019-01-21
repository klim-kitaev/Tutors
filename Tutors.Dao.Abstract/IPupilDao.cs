using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tutors.Domain;

namespace Tutors.Dao.Abstract
{
    /// <summary>
    /// Интерфейс DAO работы с учениками
    /// </summary>
    public interface IPupilDao
    {
        /// <summary>
        /// Получение списка учеников пользователя
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<Pupil>> GetPupils(int userId);

        /// <summary>
        /// Получение данных о конкретном ученике
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Pupil> GetPupil(int id);

        /// <summary>
        /// Сохранение / обновление данных об ученике
        /// </summary>
        /// <param name="pupil"></param>
        /// <returns></returns>
        Task<Pupil> SavePupil(Pupil pupil);

        /// <summary>
        /// Удаление ученика
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Pupil> DeletePupil(int id);

    }
}
