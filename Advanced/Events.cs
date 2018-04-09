// Events & Delegates

// Event:
// - mechanism for communication between objects (publisher -> subscriber)
// - used in building Lossely Coupled Applications
// - helps extending apps

// Delegate:
// - agreement/contract between Publisher and Subscriber
// - determines the signature of the event handler method in Subscriber

using System;
using System.Threading;

namespace Advanced
{
    public class Video
    {
        public string Title { get; set; }
    }

    public class VideoEncoder
    {
        // 1 - define a delegate
        public delegate void VideoEncodedEventHandler(object source, EventArgs args);

        // 2 - define an event based ont that delegate
        public event VideoEncodedEventHandler VideoEncoded;

        // 3 - raise the event
        protected virtual void OnVideoEncoded()
        {
            VideoEncoded(this, EventArgs.Empty);
        }


        public void Encode(Video video)
        {
            Console.Write($"Encoding video {video.Title}");
            Thread.Sleep(300);
            Console.Write(".");
            Thread.Sleep(300);
            Console.Write(".");
            Thread.Sleep(300);
            Console.Write(".");

            Thread.Sleep(1000);
            Console.WriteLine("\n\n");

            OnVideoEncoded();
        }
    }

    // Subscriber of the VideoEncoder publisher - send an email
    public class MailService
    {
        public void OnVideoEncoded(object source, EventArgs e)
        {
            Console.WriteLine("MailService: Sending an email...");
        }
    }

    // Subscriber of the VideoEncoder publisher - send an email
    public class MessageService
    {
        public void OnVideoEncoded(object source, EventArgs e)
        {
            Console.WriteLine("MailService: sending an SMS...");
        }
    }

    class Program
    {


        static void Main(string[] args)
        {
            var video = new Video() { Title = "Hello" };
            var videoEncoder = new VideoEncoder(); // Publisher
            var mailService = new MailService(); // Subscriber
            var messageService = new MessageService(); // Subscriber

            // create the subscriptions
            videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
            videoEncoder.VideoEncoded += messageService.OnVideoEncoded;

            videoEncoder.Encode(video);

            Console.ReadKey();
           

        }
    }
}