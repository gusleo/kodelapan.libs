using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Kodelapan.Libs.Binder.Date
{
    public class IDNDateModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            DateTimeStyles _datetimeStyle = DateTimeStyles.None;
            CultureInfo _culture = new CultureInfo("en-GB");
            if(bindingContext.ModelType == typeof(DateTime) )
            {
                ValueProviderResult value = bindingContext
                                .ValueProvider.GetValue(bindingContext.ModelName);
                
                if ( value.FirstValue != null )
                {
                    DateTime result;
                    bool success = DateTime.TryParse(value.FirstValue.ToString(), _culture, _datetimeStyle, out result);
                    if ( success )
                        return Task.FromResult(true);
                }
               
            }
            return Task.FromResult(false);
        }
    }
}
