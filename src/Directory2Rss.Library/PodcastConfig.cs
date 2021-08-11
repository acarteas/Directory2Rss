using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Directory2Rss.Library
{
    public class PodcastConfig
    {
        public string IPAddress { get; set; }
        public int HttpPort { get; set; }
        public string ListingUrl { get; set; }
        public Dictionary<string, PodcastListing> Listings { get; set; }

        public PodcastConfig()
        {
            Listings = new Dictionary<string, PodcastListing>();
            HttpPort = 80;
            IPAddress = GetLocalIPAddress();
        }

        public static List<string> GetLocalIpAddresses()
        {
            List<string> result = new List<string>();
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    result.Add(ip.ToString());
                }
            }
            return result;
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
