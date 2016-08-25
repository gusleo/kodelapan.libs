using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Xml;

namespace Kodelapan.Libs.Sitemap
{
    public class SiteMapResult : ActionResult
    {
        public SiteMapFeed Feed { private get; set; }

        public override void ExecuteResult(ActionContext context)
        {
            if (context == null )
            {
                throw new NotImplementedException("context");
            }
            context.HttpContext.Response.ContentType = "text/xml";

            var siteMapFormatter = new GoogleSiteMapFormatter(Feed);
            using ( var writer = XmlWriter.Create(context.HttpContext.Response.Body) )
            {
                siteMapFormatter.WriteTo(writer);
            }

        }
        protected static SiteMapResult SiteMap(SiteMapFeed feed)
        {
            return new SiteMapResult
            {
                Feed = feed
            };
        }
    }

}
