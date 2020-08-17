using System;
using System.Collections.Generic;
using System.Text;

namespace PodcastDirectory.Library
{
    public class PodcastItem
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string AudioUrl { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Author { get; set; }
        public string Duration { get; set; }
        public string PodcastBaseUrl { get; set; }

        public PodcastItem()
        {
            Title = "";
            Summary = "";
            AudioUrl = "";
            PublicationDate = DateTime.Now;
            Author = "";
            Duration = "";
            PodcastBaseUrl = "";
        }

        public string ToXml()
        {
            string xml = string.Format(
                "<item>" +
                    "<title>{0}</title>" +
                    "<itunes:summary>{1}</itunes:summary>" +
                    "<description>{2}</description>" +
                    "<link>{3}</link>" +
                    "<enclosure url=\"{4}\" type=\"audio/mpeg\" length=\"1024\"></enclosure>" +
                    "<pubDate>{5}</pubDate>" +
                    "<itunes:author>{6}</itunes:author>" +
                    "<itunes:duration>{7}</itunes:duration>" +
                    "<itunes:explicit>no</itunes:explicit>" +
                    "<guid>{8}</guid>" +
                "</item>",
                Title,
                Summary,
                Summary,
                PodcastBaseUrl,
                AudioUrl,
                PublicationDate.ToLongDateString(),
                Author,
                Duration,
                AudioUrl
                );
            return xml;
        }
    }
}
