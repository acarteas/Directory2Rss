using EmbedIO;
using EmbedIO.Routing;
using EmbedIO.WebApi;
using Swan;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodcastDirectory.Library.Controllers
{
    public class PodcastDirectoryController : WebApiController
    {
        public PodcastConfig Config { get; set; }

        public PodcastDirectoryController(PodcastConfig config)
        {
            Config = config;
        }

        [Route(HttpVerbs.Get, "/")]
        public async Task GetDirectory()
        {
            string baseUrl = string.Format("http://{0}", Config.IPAddress);
            HttpContext.Response.ContentType = "text/xml";
            using(var writer = HttpContext.OpenResponseText())
            {
                PodcastRss rss = new PodcastRss();
                var files = Directory.EnumerateFiles(Config.DirectoryToServe).Where(f => Config.AudioExtensions.Contains(Path.GetExtension(f)));
                foreach (var fileStr in files)
                {
                    var tfile = TagLib.File.Create(fileStr);
                    PodcastItem item = new PodcastItem()
                    {
                        Author = tfile.Tag.FirstAlbumArtist,
                        Title = tfile.Tag.Title,
                        PodcastBaseUrl = baseUrl,
                        AudioUrl = string.Format("{0}/files/{1}", baseUrl, Path.GetFileName(tfile.Name))
                    };
                    rss.AddItem(item);
                }
                await writer.WriteAsync(rss.ToXml());
            }
        }

        [Route(HttpVerbs.Get, "/files/{file}")]
        public async Task GetFile(string file)
        {
            HttpContext.Response.ContentType = "audio/mpeg";
            string filePath = Path.Join(Config.DirectoryToServe, file);
            if(File.Exists(filePath))
            {
                using (var stream = HttpContext.OpenResponseStream())
                {
                    var fileData = File.OpenRead(filePath);
                    byte[] buffer = new byte[1024];
                    int numBytesToRead = (int)fileData.Length;
                    int numBytesRead = 0;
                    while (numBytesToRead > 0)
                    {
                        int bytesRead = fileData.Read(buffer);
                        if(bytesRead == 0)
                        {
                            break;
                        }
                        numBytesRead += bytesRead;
                        numBytesToRead -= bytesRead;

                        stream.Write(buffer);
                    }
                }
            }
            
        }
    }
}
