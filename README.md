# Directory2Rss

Do you listen to MP3-based audio books on your phone?  Do you wish the audio books worked more like podcasts where the player remembers your place and you can skip back and forward like you do in a podcast or with Audible?  Me too!

This project allows you to temporarily host a user-specified folder on your hard drive as a podcast RSS feed.  Use your favorite podcast player to download your files to your phone and then quit the app.  Enjoy!

## Requirements 
* .NET Core 3.1 (Windows, Mac, Linux)
* Both device and PC must be on the same network
* Port 80 open on your PC's firewall (Windows will give you an UAC prompt; Linux likely must open firewall manually)

## Usage

### Step #1: Create a config file
The easiest way to get started is to rename ```config.example.json``` to ```config.json```.  Replace the placeholder text with values appropriate to your setup (e.g. IP address, directory to host, title, etc.).

### Step #2: Run the application
On Windows, run ```Directory2Rss.exe```
On Linux (assume Mac as well), run ```dotnet Directory2Rss.dll``` from the terminal.

![Server Started](docs/images/WebServerStarted.png)

To test locally on your PC, visit the IP address in your favorite web browser. You should see a link to the RSS feed (http://IP_ADDRESS/rss).  Use this address to add the podcast feed to your device.  Once all of the episodes are downloaded, kill the web server (CTRL + C).  From here, you should be good to go!
