using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kodelapan.Libs.Html
{
    public static class HtmlParser
    {
        public static string removeAllTags(this string html)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            return doc.DocumentNode.InnerText;
        }
        public static string removeTags(this string html, string[] unwantedTags)
        {
            if ( String.IsNullOrEmpty(html) )
            {
                return html;
            }

            var document = new HtmlDocument();
            document.LoadHtml(html);

            HtmlNodeCollection tryGetNodes = document.DocumentNode.SelectNodes("./*|./text()");

            if ( tryGetNodes == null || !tryGetNodes.Any() )
            {
                return html;
            }

            var nodes = new Queue<HtmlNode>(tryGetNodes);

            while ( nodes.Count > 0 )
            {
                var node = nodes.Dequeue();
                var parentNode = node.ParentNode;

                var childNodes = node.SelectNodes("./*|./text()");

                if ( childNodes != null )
                {
                    foreach ( var child in childNodes )
                    {
                        nodes.Enqueue(child);
                    }
                }

                if ( unwantedTags.Any(tag => tag == node.Name) )
                {
                    if ( childNodes != null )
                    {
                        foreach ( var child in childNodes )
                        {
                            parentNode.InsertBefore(child, node);
                        }
                    }

                    parentNode.RemoveChild(node);

                }
            }

            return document.DocumentNode.InnerHtml;
        }
    }
}
