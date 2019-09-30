using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.Extensions.Configuration;
using ServiceModule = Tutors.Iocs.AutofacConfigurator.AssemblyModule;

namespace Tutors.WebApi.Configurations
{
    public class AssemblyModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public AssemblyModule(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }


        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new ServiceModule(_configuration.GetValue<string>("connectionStrings:MongoDb")));
        }
    }
}
