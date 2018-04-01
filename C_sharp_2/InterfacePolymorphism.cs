using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacePolymorphism
{
    // interface that could be used for SMS, Email, Console...
    public interface INotificationChannel
    {
        void Send(Message message);
    }

    // implements INotif for mails
    public class MailNotificationChannel : INotificationChannel
    {
        public void Send(Message message)
        {
            Console.WriteLine("Email sent.");
        }
    }

    // implements INotif for SMS
    public class SmsNotificationChannel : INotificationChannel
    {
        public void Send(Message message)
        {
            Console.WriteLine("SMS sent.");
        }
    }

    public class Message
    {

    }

    public class Mail
    {

    }

    public class Video
    {

    }

    public class MailService
    {
        public void Send(Mail mail)
        {
            Console.WriteLine("Sending email...");
        }
    }

    public class VideoEncoder
    {
        // Interface List to store all the Notifications classes that implement the interface
        private readonly IList<INotificationChannel> _notificationChannels;

        public VideoEncoder()
        {
            _notificationChannels = new List<INotificationChannel>();
        }

        // depending on which Notification channel (class) is in the list, the Send() method of that class is triggered
        // --> Polymorphism
        public void Encode(Video video)
        {
            foreach (var channel in _notificationChannels)
            {
                channel.Send(new Message());
            }
        }

        // to add a new notification channel to the list
        public void RegisterNotificationChannel(INotificationChannel channel)
        {
            _notificationChannels.Add(channel);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var encoder = new VideoEncoder();
            encoder.RegisterNotificationChannel(new MailNotificationChannel());
            encoder.RegisterNotificationChannel(new SmsNotificationChannel());
            encoder.Encode(new Video());
            Console.ReadKey();
        }
    }
}
