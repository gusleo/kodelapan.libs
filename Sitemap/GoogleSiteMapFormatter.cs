using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Kodelapan.Libs.Sitemap
{
    public class GoogleSiteMapFormatter
    {
        private SiteMapFeed siteMap;

        public GoogleSiteMapFormatter(SiteMapFeed feedToFormat)
        {
            siteMap = feedToFormat;
        }

        public void WriteTo(XmlWriter writer)
        {
            XNamespace ns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            var sitemap = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement(ns + "urlset",
                         siteMap.Items
                         .Select(item => new XElement(ns + "url",
                                  new XElement(ns + "loc", item.Url),
                                  new XElement(ns + "lastmod", item.Modified.ToW3CDate()),
                                  new XElement(ns + "changefreq", item.ChangeFrequency.ToString().ToLower()),
                                  new XElement(ns + "priority", item.Priority)
                                )
                              )
                            )
                        );
            sitemap.Save(writer);
        }
    }
}
