using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace PodcastDirectory.Library
{
    public class PodcastConfig
    {
        public string DirectoryToServe { get; set; }
        public List<string> AudioExtensions { get; set; }
        public string IPAddress { get; set; }
        public string PodcastTitle { get; set; }
        public string PodcastDescription { get; set; }
        public string Author { get; set; }
        public string PodcastOwner { get; set; }
        public string PodcastCategory { get; set; }

        public PodcastConfig()
        {
            DirectoryToServe = Directory.GetCurrentDirectory();
            IPAddress = GetLocalIPAddress();
            AudioExtensions = new List<string>();
            AudioExtensions.Add(".mp3");
            PodcastTitle = "PodcastDirectory";
            PodcastDescription = "A directory being served as a podcast RSS feed";
            Author = "PodcastDirectory";
            PodcastOwner = "PodcastDirectory";
            PodcastCategory = "Music";
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}
