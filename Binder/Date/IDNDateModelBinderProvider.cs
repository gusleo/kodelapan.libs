using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Linq;
using System.Reflection;

namespace Kodelapan.Libs.Binder.Date
{
    public class IDNDateModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if ( context == null ) throw new ArgumentNullException(nameof(context));

            if ( !context.Metadata.IsComplexType )
            {
                if(context.Metadata.ModelType == typeof(DateTime) )
                {
                    try
                    {
                        // Look for scrubber attributes
                        var propName = context.Metadata.PropertyName;
                        var propInfo = context.Metadata.ContainerType.GetProperty(propName);

                        // Only one scrubber attribute can be applied to each property
                        var attribute = propInfo.GetCustomAttributes(typeof(IDNDateScrubberAttribute), false).FirstOrDefault();
                        if ( attribute != null ) return new IDNDateModelBinder(context.Metadata.ModelType, attribute as IScrubberAttribute);
                    }
                    catch(Exception ex )
                    {
                        return null;
                    }
                   
                }
                
            }

            return null;
        }
    }
}
