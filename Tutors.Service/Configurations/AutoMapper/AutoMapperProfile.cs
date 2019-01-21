using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Dto = Tutors.Service.Dto;
using Domain = Tutors.Domain;

namespace Tutors.Service.Configurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Domain.Pupil, Dto.PupilInfo>();
            CreateMap<Dto.PupilInfo,Domain.Pupil>();

            CreateMap<Domain.Pupil, Dto.PupilInfoListItem>()
                .ForMember(o => o.Name, m => m.MapFrom(s => $"{s.FirstName} {s.LastName}".Trim()));
        }
    }
}
