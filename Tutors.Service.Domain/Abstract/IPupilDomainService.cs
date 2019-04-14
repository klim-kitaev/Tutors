using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tutors.Domain;

namespace Tutors.Service.Domain.Abstract
{
    /// <summary>
    /// Интерфейс сервиса работы с учениками
    /// </summary>
    public interface IPupilDomainService
    {
        /// <summary>
        /// Получение данных о конкретном ученике
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<Pupil> GetPupil(int id, int userId);

        /// <summary>
        /// Получение списка учеников пользователя
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<Pupil>> GetPupils(int userId);


        /// <summary>
        /// Удаление ученика
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<Pupil> DeletePupil(int id, int userId);

        /// <summary>
        /// Сохранение / обновление данных об ученике
        /// </summary>
        /// <param name="pupil"></param>
        /// <returns></returns>
        Task<Pupil> SavePupil(Pupil pupil);
    }
}
