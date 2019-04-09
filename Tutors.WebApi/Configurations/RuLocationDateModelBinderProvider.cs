using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tutors.WebApi.Configurations
{
    public class RuLocationDateModelBinderProvider : IModelBinderProvider
    {        
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            return context.Metadata.ModelType == typeof(DateTime) ? new DateTimeModelBinder() : null;
        }
    }
}
