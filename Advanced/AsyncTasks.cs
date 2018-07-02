using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;


/*
Synchronous:
- program executed line by line
- program waits until functions returns the call


Asynchronous:
- Program doesn't wait for function returns, it keeps executing the next lines
- Improves responsiveness (ex. media players, web browsers)
--> multi-threading, callbacks, async/await (task-based asynchronous model)

*/

namespace AsynchronousProgramming
{
    class Program
    {

        // async methods are defined by the keywords "async" followed by "Task" in the signature
        // and keyword "await" in front of async method calls (tasks)
        public static async Task DownloadHtmlAsync (string url)
        {
            var watchMethod = Stopwatch.StartNew();
            var webClient = new WebClient();
            var html = await webClient.DownloadStringTaskAsync(url);

            using (var streamWriter = new StreamWriter(@"C:\Users\i344559\Desktop\result.html"))
            {
                await streamWriter.WriteAsync(html);
            }
            watchMethod.Stop();
            var elapsedMs = watchMethod.ElapsedMilliseconds;
            Console.WriteLine($"Method has taken {elapsedMs} Milliseconds.");
        }

        // synchronous version (not used)
        public static void DownloadHtml (string url)
        {
            var watchMethod = Stopwatch.StartNew();
            var webClient = new WebClient();
            var html = webClient.DownloadString(url);

            using (var streamWriter = new StreamWriter(@"C:\Users\i344559\Desktop\result.html"))
            {
                streamWriter.Write(html);
            }
            watchMethod.Stop();
            var elapsedMs = watchMethod.ElapsedMilliseconds;
            Console.WriteLine($"Method has taken {elapsedMs} Milliseconds.");
        }

        // async method with a return type string
        public static async Task<string> GetHtmlAsync (string url)

        {
            var webClient = new WebClient();
            return await webClient.DownloadStringTaskAsync(url);
        }

        // await can only work in async methods 
        public static async Task DisplayHtml()
        {
            var html = await GetHtmlAsync("http://www.concur.com");
            Console.WriteLine(html.Substring(0,1000));
        }

        static void Main(string[] args)
        {
            var watchProgram = Stopwatch.StartNew();
            // calling the async method: next instruction will be executed before the page is done downloading
            DownloadHtmlAsync("http://www.concur.com");
            // DisplayHtml();
            watchProgram.Stop();
            var elapsedMs = watchProgram.ElapsedMilliseconds;
            Console.WriteLine($"Async method call has taken {elapsedMs} Milliseconds.");
            Console.WriteLine("");
            Console.ReadKey();
        }
    }
}
