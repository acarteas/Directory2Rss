using PodcastDirectory.Library;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PodcastDirectory.ConsoleApp
{
    class Program
    {
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

            PodcastDirectoryServer server = new PodcastDirectoryServer(config);
            await server.StartAsync();
            Console.WriteLine("Shutting down server...");
        }
    }
}
