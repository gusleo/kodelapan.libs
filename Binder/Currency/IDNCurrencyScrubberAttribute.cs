using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Kodelapan.Libs.Binder.Currency
{

    [AttributeUsage(AttributeTargets.Property)]
    public class IDNCurrencyScrubberAttribute : Attribute, IScrubberAttribute
    {
        private static NumberStyles _currencyStyle = NumberStyles.Currency;
        private CultureInfo _culture = new CultureInfo("id-ID");

        public object Scrub(string modelValue, out bool success)
        {
            var modelDecimal = 0M;
            success = decimal.TryParse(
                modelValue,
                _currencyStyle,
                _culture,
                out modelDecimal
            );

            return modelDecimal;
        }
    }
}
