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
                "<item>\n" +
                    "<title>{0}</title>\n" +
                    "<itunes:summary>{1}</itunes:summary>\n" +
                    "<description>{2}</description>\n" +
                    "<link>{3}</link>\n" +
                    "<enclosure url=\"{4}\" type=\"audio/mpeg\" length=\"1024\"></enclosure>\n" +
                    "<pubDate>{5}</pubDate>\n" +
                    "<itunes:author>{6}</itunes:author>\n" +
                    "<itunes:duration>{7}</itunes:duration>\n" +
                    "<itunes:explicit>no</itunes:explicit>\n" +
                    "<guid>{8}</guid>\n" +
                "</item>\n",
                Title,
                Summary,
                Summary,
                PodcastBaseUrl,
                AudioUrl,
                string.Format("{0} GMT", PublicationDate.ToUniversalTime().ToString("ddd, dd MMM yyyy HH:mm:ss")),
                Author,
                Duration,
                AudioUrl
                );
            return xml;
        }
    }
}
