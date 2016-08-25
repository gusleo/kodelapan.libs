using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kodelapan.Libs.Sitemap
{
    public enum ChangeFrequency
    {
        Always,
        Hourly,
        Daily,
        Weekly,
        Monthly,
        Yearly,
        Never
    }

    public class SiteMapFeedItem
    {
        private Double _priority = 0.5;

        public Uri Url { get; set; }
        public DateTime Modified { get; set; }
        public Enum ChangeFrequency { get; set; }
        public Double? Priority { get; set; }
    }
}
