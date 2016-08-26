using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace Kodelapan.Libs.Binder.Date
{
    public class IDNDateModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if ( context == null )
            {
                throw new ArgumentNullException(nameof(context));
            }
            if(context.Metadata.ModelType != typeof(DateTime) )
            {
                return null;
            }
            
            return new IDNDateModelBinder();
        }
    }
}
