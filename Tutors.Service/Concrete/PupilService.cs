using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tutors.Dao.Abstract;
using Tutors.Service.Abstract;
using Dto = Tutors.Service.Dto;

namespace Tutors.Service.Concrete
{
    /// <summary>
    /// Реализация сервиса работы с учениками
    /// </summary>
    public class PupilService : IPupilService
    {
        private readonly IPupilDao _pupilDao;
        private readonly IMapper _mapper;

        public PupilService(IPupilDao pupilDao, IMapper mapper)
        {
            _pupilDao = pupilDao ?? throw new ArgumentNullException(nameof(pupilDao));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        private Dto.PupilInfo _Convert(Domain.Pupil pupil) => _mapper.Map<Dto.PupilInfo>(pupil);

        private Domain.Pupil _Convert(Dto.PupilInfo pupil) => _mapper.Map<Domain.Pupil>(pupil);

        private async Task<Domain.Pupil> _Find(int id, int userId)
        {
            Domain.Pupil pupil = await _pupilDao.GetPupil(id);

            if (pupil == null || pupil.UserId != userId)
                return null;

            return pupil;
        }

        /// <summary>
        /// Удалить ученика
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<Dto.PupilInfo> DeletePupilInfo(int id, int userId)
        {
            Domain.Pupil pupil = await _Find(id, userId);

            if (pupil == null)
                return null;

            pupil = await _pupilDao.DeletePupil(id);
            return _Convert(pupil);
        }

        /// <summary>
        /// Получить данные по ученику
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<Dto.PupilInfo> GetPupilInfo(int id, int userId)
        {
            Domain.Pupil pupil = await _Find(id, userId);
            return _Convert(pupil);
        }

        /// <summary>
        /// Получить список учеников
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<Dto.PupilInfoListItem>> GetPupils(int userId)
        {
            List<Domain.Pupil> pupils = await _pupilDao.GetPupils(userId);
            return _mapper.Map<List<Dto.PupilInfoListItem>>(pupils);
        }

        /// <summary>
        /// Сохранить / обновить данные об ученике
        /// </summary>
        /// <param name="pupil"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<Dto.PupilInfo> SavePupilInfo(Dto.PupilInfo pupil, int userId)
        {
            Domain.Pupil domainPupil = _Convert(pupil);
            domainPupil.PriceList = new Dictionary<Domain.LessonDuration, decimal>();
            if(pupil.OneHourPrice != null)
            {
                domainPupil.PriceList.Add(Domain.LessonDuration.OneHour, pupil.OneHourPrice.Value);
            }
            if (pupil.OneAndHalfPrice != null)
            {
                domainPupil.PriceList.Add(Domain.LessonDuration.OneAndHalf, pupil.OneAndHalfPrice.Value);
            }
            if (pupil.TwoHourPrice != null)
            {
                domainPupil.PriceList.Add(Domain.LessonDuration.TwoHour, pupil.TwoHourPrice.Value);
            }
            domainPupil.UserId = userId;
            domainPupil = await _pupilDao.SavePupil(domainPupil);
            return _Convert(domainPupil);
        }
    }
}
