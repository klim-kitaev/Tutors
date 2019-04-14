using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tutors.Dao.Abstract;
using Tutors.Domain;
using Tutors.Service.Domain.Abstract;

namespace Tutors.Service.Domain.Concrete
{
    /// <summary>
    /// Реализация сервиса работы с учениками
    /// </summary>
    public class PupilDomainService : IPupilDomainService
    {
        private readonly IPupilDao _pupilDao;

        public PupilDomainService(IPupilDao pupilDao)
        {
            _pupilDao = pupilDao ?? throw new ArgumentNullException(nameof(pupilDao));
        }

        /// <summary>
        /// Получение данных о конкретном ученике
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<Pupil> GetPupil(int id, int userId)
        {
            var pupil = await _pupilDao.GetPupil(id);

            if (pupil == null || pupil.UserId != userId)
                return null;

            return pupil;
        }

        /// <summary>
        /// Получение списка учеников пользователя
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<Pupil>> GetPupils(int userId)
        {
            return await _pupilDao.GetPupils(userId);
        }

        /// <summary>
        /// Удаление ученика
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<Pupil> DeletePupil(int id, int userId)
        {
            var pupil = await GetPupil(id, userId);
            if (pupil == null)
                return null;

            return await _pupilDao.DeletePupil(id);
        }

        /// <summary>
        /// Сохранение / обновление данных об ученике
        /// </summary>
        /// <param name="pupil"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<Pupil> SavePupil(Pupil pupil)
        {
            return await _pupilDao.SavePupil(pupil);
        }
    }
}
