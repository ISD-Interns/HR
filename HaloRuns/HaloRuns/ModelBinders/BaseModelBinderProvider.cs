using HaloRuns.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaloRuns.ModelBinders
{
    public class BaseModelBinderProvider : IModelBinderProvider
	{
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.BindingInfo.BindingSource?.IsFromRequest == true)
			{
                return null;
			}

            //if (context.Metadata.ModelType != typeof(DbSet<>))
            if (context.Metadata.ModelType.Namespace != "HaloRuns.Models")
            {
                return null;
			}

            //return new BaseModelBinder<User>();
            var generic = typeof(BaseModelBinder<>);

			//returns: BaseModelBinder<>
            var specific = generic.MakeGenericType(context.Metadata.ModelType);
            // T static_cast<T>(object obj){ return (T)obj; }
            // static_cast<int>(Activator.CreateInstance(specific)).myprop;
            // ((int)(Activator.CreateInstance(specific))).myprop;
            return (IModelBinder) Activator.CreateInstance(specific);
        }
	}
}
