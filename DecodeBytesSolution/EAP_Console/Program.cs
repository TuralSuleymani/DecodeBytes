using System.ComponentModel;
using System.Net;

namespace EAP_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WebClient client = new();
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCallback!);
            client.DownloadFileAsync(new Uri("https://filesamples.com/samples/document/txt/sample3.txt"), @"C:\test\file.txt");

            Console.WriteLine("Hello, World!");
            Console.ReadLine();
        }
       static void DownloadFileCallback(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Console.WriteLine("Download failed: {0}", e.Error.Message);
            }
            else
            {
                Console.WriteLine("Download completed successfully!");
            }
        }
    }
}
