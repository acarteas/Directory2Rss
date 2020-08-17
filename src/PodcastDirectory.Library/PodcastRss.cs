using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace PodcastDirectory.Library
{
    public class PodcastRss
    {
        private List<PodcastItem> _items = new List<PodcastItem>();

        public string Title { get; set; }
        public string PodcastUrl { get; set; }
        public string Subtitle { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
        public string OwnerEmail { get; set; }
        public string PodcastImageUrl { get; set; }
        public string Category { get; set; }

        public PodcastRss()
        {
            Title = "";
            PodcastUrl = "";
            Subtitle = "";
            Author = "";
            Description = "";
            Owner = "";
            OwnerEmail = "";
            PodcastImageUrl = "";
            Category = "";
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
                "<?xml version=\"1.0\" encoding=\"UTF - 8\"?>" +
                "<rss xmlns:itunes=\"http://www.itunes.com/dtds/podcast-1.0.dtd\" version=\"2.0\">" +
                    "<channel>" +
                        "<title>{0}</title>" +
                        "<link>{1}<link>" +
                        "<language>en-us</language>" +
                        "<itunes:subtitle>{2}</itunes:subtitle>" +
                        "<itunes:author>{3}</itunes:author>" +
                        "<itunes:summary>{4}</itunes:summary>" +
                        "<description>{5}</description>" +
                        "<itunes:owner>" +
                            "<itunes:name>{6}</itunes:name>" +
                            "<itunes:email>{7}</itunes:email>" +
                        "</itunes:owner>" +
                        "<itunes:explicit>no</itunes:explicit>" +
                        "<itunes:image href=\"{8}\" />" +
                        "<itunes:category text=\"{9}\"/></itunes:category>" +
                        "{10}" +
                    "</channel>" +
                "</rss>",
                Title,
                PodcastUrl,
                Subtitle,
                Author,
                Description,
                Description,
                Owner,
                OwnerEmail,
                PodcastImageUrl,
                Category,
                itemsXml
                );
            return xml;
        }
    }
}
