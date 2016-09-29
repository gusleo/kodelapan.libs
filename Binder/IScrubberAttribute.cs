using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kodelapan.Libs.Binder
{
    public interface IScrubberAttribute
    {
        object Scrub(string modelValue, out bool success);
    }
}
