using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tutors.Dao.Abstract;
using Tutors.Domain;
using Tutors.Service.Abstract;
using Tutors.Service.Domain.Abstract;
using Dto = Tutors.Service.Dto;

namespace Tutors.Service.Concrete
{
    /// <summary>
    /// Реализация сервиса работы с учениками
    /// </summary>
    public class PupilService : IPupilService
    {
        private readonly IPupilDomainService _pupilDomainService;
        private readonly IMapper _mapper;

        public PupilService(IPupilDomainService pupilDomainService, IMapper mapper)
        {
            _pupilDomainService = pupilDomainService ?? throw new ArgumentNullException(nameof(pupilDomainService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        private Dto.PupilInfo _Convert(Pupil pupil) => _mapper.Map<Dto.PupilInfo>(pupil);

        private Pupil _Convert(Dto.PupilInfo pupil) => _mapper.Map<Pupil>(pupil);
        

        /// <summary>
        /// Удалить ученика
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<Dto.PupilInfo> DeletePupilInfo(int id, int userId)
        {
            var pupil = await _pupilDomainService.DeletePupil(id, userId);
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
            Pupil pupil = await _pupilDomainService.GetPupil(id, userId);
            return _Convert(pupil);
        }

        /// <summary>
        /// Получить список учеников
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<Dto.PupilInfoListItem>> GetPupils(int userId)
        {
            List<Pupil> pupils = await _pupilDomainService.GetPupils(userId);
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
            Pupil domainPupil = _Convert(pupil);
            domainPupil.PriceList = new Dictionary<LessonDuration, decimal>();
            if(pupil.OneHourPrice != null)
            {
                domainPupil.PriceList.Add(LessonDuration.OneHour, pupil.OneHourPrice.Value);
            }
            if (pupil.OneAndHalfPrice != null)
            {
                domainPupil.PriceList.Add(LessonDuration.OneAndHalf, pupil.OneAndHalfPrice.Value);
            }
            if (pupil.TwoHourPrice != null)
            {
                domainPupil.PriceList.Add(LessonDuration.TwoHour, pupil.TwoHourPrice.Value);
            }
            domainPupil.UserId = userId;
            domainPupil = await _pupilDomainService.SavePupil(domainPupil);
            return _Convert(domainPupil);
        }
    }
}
