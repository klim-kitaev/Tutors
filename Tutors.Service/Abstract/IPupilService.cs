using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tutors.Service.Dto;

namespace Tutors.Service.Abstract
{
    /// <summary>
    /// Интерфейс сервиса работы с учениками
    /// </summary>
    public interface IPupilService
    {
        /// <summary>
        /// Получить список учеников
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<PupilInfoListItem>> GetPupils(int userId);
        /// <summary>
        /// Получить данные по ученику
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<PupilInfo> GetPupilInfo(int id, int userId);

        /// <summary>
        /// Сохранить / обновить данные об ученике
        /// </summary>
        /// <param name="pupil"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<PupilInfo> SavePupilInfo(PupilInfo pupil, int userId);
        /// <summary>
        /// Удалить ученика
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<PupilInfo> DeletePupilInfo(int id, int userId);
    }
}
