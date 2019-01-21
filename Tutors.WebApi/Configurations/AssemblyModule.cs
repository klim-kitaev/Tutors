using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using ServiceModule = Tutors.Iocs.AutofacConfigurator.AssemblyModule;

namespace Tutors.WebApi.Configurations
{
    public class AssemblyModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new ServiceModule());
        }
    }
}
