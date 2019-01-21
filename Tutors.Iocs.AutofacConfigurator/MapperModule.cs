using System;
using Autofac;
using AutoMapper;
namespace Tutors.Iocs.AutofacConfigurator
{
    public class MapperModule : Autofac.Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            var mapper = new Mapper(CreateMapperConfiguration());
            builder.RegisterInstance<IMapper>(mapper).SingleInstance();
        }


        private MapperConfiguration CreateMapperConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new Service.Configurations.AutoMapperProfile());
            });

            return config;
        }

    }
}
