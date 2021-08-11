using Directory2Rss.Library;
using Newtonsoft.Json;
using Swan;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Directory2Rss.ConsoleApp
{
    class Program
    {
        private const string CONFIG_FILE_NAME = "config.json";
        static void GenerateEmptyConfig()
        {
            PodcastConfig config = new PodcastConfig();
            config.Listings.Add("<ENTER UNIQUE, SHORT TITLE (NO SPACES)>", new PodcastListing());
            config.ListingUrl = "<ENTER PUBLIC FACING URL (e.g. http://mywebsite.com OR http://localhost)>";
            config.IPAddress = "<ENTER YOUR IP ADDRESS>";
            config.Listings.FirstOrDefault().Value.PodcastTitle = "<ENTER PODCAST TITLE>";
            config.Listings.FirstOrDefault().Value.DirectoryToServe = "<ENTER DIRECTORY THAT CONTAINS PODCAST (e.g. C:/Podcasts/MyFavoritePodcast)>";
            using (StreamWriter writer = File.CreateText(CONFIG_FILE_NAME))
            {
                writer.Write(JsonConvert.SerializeObject(config, Formatting.Indented));
            }
        }

        /// <summary>
        /// Sets the referenced input variable to the supplied option if not empty
        /// </summary>
        /// <param name="input"></param>
        /// <param name="option"></param>
        static void setOption(ref string input, string option)
        {
            if (option.Length > 0)
            {
                input = option;
            }
        }

        static async Task Main(string[] args)
        {
            if (File.Exists(CONFIG_FILE_NAME) == false)
            {
                Console.WriteLine("No config detected.  Generating blank config...");
                GenerateEmptyConfig();
                Console.WriteLine("Blank config created.  Please edit and rerun this application.");
            }
            else
            {
                PodcastConfig config = null;
                try
                {
                    config = JsonConvert.DeserializeObject<PodcastConfig>(File.ReadAllText(CONFIG_FILE_NAME));
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Existing config file corrupted.");
                    return;
                }

                Directory2RssServer server = new Directory2RssServer(config);
                await server.StartAsync();
            }

            Console.WriteLine("Shutting down server...");
        }
    }
}
