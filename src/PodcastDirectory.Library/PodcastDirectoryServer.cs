using EmbedIO;
using PodcastDirectory.Library.Controllers;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace PodcastDirectory.Library
{
    public class PodcastDirectoryServer
    {
        public PodcastConfig Config { get; set; }
        public PodcastDirectoryServer(PodcastConfig config)
        {
            Config = config;
        }

        /// <summary>
        /// starts the web server as a blocking async call
        /// </summary>
        public async Task StartAsync()
        {
            await RunWebServer();
        }

        private async Task RunWebServer()
        {
            //non-admin users must run on localhost only
            using (var server = new WebServer(string.Format("http://{0}:80", Config.IPAddress)))
            {
                //Assembly assembly = typeof(App).Assembly;
                PodcastDirectoryController controller = new PodcastDirectoryController(Config);
                server.WithLocalSessionManager();
                server.WithWebApi("/", m => m.RegisterController(() => controller));
                await server.RunAsync();
            }
        }
    }
}
