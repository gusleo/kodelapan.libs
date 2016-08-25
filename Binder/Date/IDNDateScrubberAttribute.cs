using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Kodelapan.Libs.Binder.Date
{
    public class IDNDateScrubberAttribute : Attribute, IScrubberAttribute
    {
        private static DateTimeStyles _datetimeStyle = DateTimeStyles.None;
        private CultureInfo _culture = new CultureInfo("id-ID");

        public object Scrub(string modelValue, out bool success)
        {
            DateTime modelDate = DateTime.Now;
            success = DateTime.TryParse(
                modelValue,
                _culture,
                _datetimeStyle,
                out modelDate
            );

            return modelDate;
        }
    }
}
