using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Directory2Rss.Library
{
    public class PodcastRss
    {
        private List<PodcastItem> _items = new List<PodcastItem>();

        public PodcastListing Listing { get; set; }
        public string IpAddress { get; set; }

        public PodcastRss(PodcastListing listing, string ipAddress)
        {
            Listing = listing;
            IpAddress = ipAddress; 
        }

        public void AddItem(PodcastItem item)
        {
            _items.Add(item);
        }

        public string ToXml()
        {
            var itemsXml = new StringBuilder();
            foreach(var item in _items)
            {
                itemsXml.Append(item.ToXml());
            }

            string xml = string.Format(
                "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n" +
                "<rss xmlns:itunes=\"http://www.itunes.com/dtds/podcast-1.0.dtd\" version=\"2.0\">\n" +
                    "<channel>\n" +
                        "<title>{0}</title>\n" +
                        "<link>{1}</link>\n" +
                        "<language>en-us</language>\n" +
                        "<itunes:author>{2}</itunes:author>\n" +
                        "<description>{3}</description>\n" +
                        "<itunes:owner>\n" +
                            "<itunes:name>{4}</itunes:name>\n" +
                        "</itunes:owner>\n" +
                        "<itunes:explicit>no</itunes:explicit>\n" +
                        "<itunes:image href=\"{5}\" />\n" +
                        "<itunes:category text=\"{6}\"/>\n" +
                        "{7}\n" +
                    "</channel>\n" +
                "</rss>",
                Listing.PodcastTitle,
                string.Format("http://{0}", IpAddress),
                Listing.PodcastOwner,
                Listing.PodcastDescription,
                Listing.PodcastOwner,
                string.Format("http://{0}/image", IpAddress),
                Listing.PodcastCategory,
                itemsXml
                );
            return xml;
        }
    }
}
