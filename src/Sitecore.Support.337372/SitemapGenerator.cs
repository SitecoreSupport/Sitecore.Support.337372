using System;
using System.Xml;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.XA.Feature.SiteMetadata.Sitemap;

namespace Sitecore.Support.XA.Feature.SiteMetadata.Sitemap
{
    public class SitemapGenerator : Sitecore.XA.Feature.SiteMetadata.Sitemap.SitemapGenerator
    {
        public SitemapGenerator() :base()
        {
        }

        public SitemapGenerator(XmlWriterSettings xmlWriterSettings) :base(xmlWriterSettings)
        {
        }
        
        protected override string GetFullLink(Item item, SitemapLinkOptions options)
        {
            Uri uri = null;
            string relativeUrl = LinkManager.GetItemUrl(item, options.UrlOptions);
            if (!relativeUrl.StartsWith("/", StringComparison.Ordinal))
            {
                uri = new Uri(relativeUrl);
                relativeUrl = uri.LocalPath;
            }
            return options.Scheme + Uri.SchemeDelimiter + options.TargetHostname + relativeUrl;
        }
    }
}