using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Directory2Rss.Library
{
    public class PodcastConfig
    {
        public string IPAddress { get; set; }
        public int HttpPort { get; set; } = 80;
        public string ListingUrl { get; set; }
        public bool ShowIndexListing {get;set;} = false;
        public Dictionary<string, PodcastListing> Listings { get; set; }

        public PodcastConfig()
        {
            Listings = new Dictionary<string, PodcastListing>();
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
            try{
                return GetLocalIpAddresses().First();
            }
            catch(Exception ex) {
                Console.WriteLine("Could not automatically determine IP address.");
            }

            return "";
        }
    }
}
