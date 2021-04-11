using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Directory2Rss.Library
{
    public class PodcastListing
    {
        public string DirectoryToServe { get; set; }
        public List<string> AudioExtensions { get; set; }
        public string PodcastTitle { get; set; }
        public string TrackTitleSource { get; set; }
        public string PodcastDescription { get; set; }
        public string PodcastOwner { get; set; }
        public string PodcastCategory { get; set; }
        public bool SortByTitle { get; set; }

        public PodcastListing()
        {
            DirectoryToServe = Directory.GetCurrentDirectory();
            AudioExtensions = new List<string>();
            AudioExtensions.Add(".mp3");
            PodcastTitle = "Directory2Rss";
            PodcastDescription = "A directory being served as a podcast RSS feed";
            PodcastOwner = "Directory2Rss";
            TrackTitleSource = "metadata";
            PodcastCategory = "Music";
            SortByTitle = true;
        }

    }
}
