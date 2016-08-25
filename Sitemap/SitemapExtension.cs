using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kodelapan.Libs.Sitemap
{
    public static class SiteMapExtension
    {
        public static string ToW3CDate(this DateTime dt)
        {
            return dt.ToUniversalTime().ToString("s") + "Z";
        }
    }
}
