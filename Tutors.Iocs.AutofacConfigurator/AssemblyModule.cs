using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Autofac;
using Tutors.Dao.Abstract;
using Tutors.Service.Abstract;
using Tutors.Service.Concrete;
using Tutors.Service.Domain.Abstract;
using Tutors.Service.Domain.Concrete;
using MemoryDao = Tutors.Dao.Memory;
using MongoDao = Tutors.Dao.Mongo;

namespace Tutors.Iocs.AutofacConfigurator
{
    public class AssemblyModule : Autofac.Module
    {
        private readonly string _mongoDbConnctionString;

        public AssemblyModule(string mongoDbConnctionString)
        {
            _mongoDbConnctionString = mongoDbConnctionString ?? throw new ArgumentNullException(nameof(mongoDbConnctionString));
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<MapperModule>();
            _RegisterDao(builder);
            _RegisterServices(builder);
            _RegisterDomainServices(builder);
        }

        private void _RegisterDao(ContainerBuilder builder)
        {
            //builder.RegisterType<MemoryDao.PupilDao>().As<IPupilDao>();
            builder.RegisterType<MongoDao.MongoPupilDao>().As<IPupilDao>().WithParameter("connectionString", _mongoDbConnctionString);
        }

        private void _RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<PupilService>().As<IPupilService>();
            builder.RegisterType<LessonService>().As<ILessonService>();
        }

        private void _RegisterDomainServices(ContainerBuilder builder)
        {
            builder.RegisterType<SheduleService>().As<ISheduleService>();
            builder.RegisterType<PupilDomainService>().As<IPupilDomainService>();
            builder.RegisterType<LessonDomainService>().As<ILessonDomainService>();
        }

    }
}
