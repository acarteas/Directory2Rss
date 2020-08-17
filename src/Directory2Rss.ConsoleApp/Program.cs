using Directory2Rss.Library;
using Swan;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Directory2Rss.ConsoleApp
{
    class Program
    {
        /// <summary>
        /// Sets the referenced input variable to the supplied option if not empty
        /// </summary>
        /// <param name="input"></param>
        /// <param name="option"></param>
        static void setOption(ref string input, string option)
        {
            if(option.Length > 0)
            {
                input = option;
            }
        }

        static async Task Main(string[] args)
        {
            PodcastConfig config = new PodcastConfig();
            Console.WriteLine("Enter directory to serve [{0}]: ", config.DirectoryToServe);
            string response = Console.ReadLine();
            if(response.Length > 0)
            {
                if(Directory.Exists(response))
                {
                    config.DirectoryToServe = response;
                }
                else
                {
                    Console.WriteLine("Could not find directory, exiting...");
                    return;
                }
            }

            Console.WriteLine("Enter podcast title [{0}]: ", config.PodcastTitle);
            response = config.PodcastTitle;
            setOption(ref response, Console.ReadLine());
            config.PodcastTitle = response;

            Console.WriteLine("Enter podcast description [{0}]: ", config.PodcastDescription);
            response = config.PodcastDescription;
            setOption(ref response, Console.ReadLine());
            config.PodcastDescription = response;

            Console.WriteLine("Enter podcast owner [{0}]: ", config.PodcastOwner);
            response = config.PodcastOwner;
            setOption(ref response, Console.ReadLine());
            config.PodcastOwner = response;

            Directory2RssServer server = new Directory2RssServer(config);
            await server.StartAsync();
            Console.WriteLine("Shutting down server...");
        }
    }
}
