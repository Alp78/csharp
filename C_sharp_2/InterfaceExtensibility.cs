using System;
using System.IO;

namespace Interface_Extensibility
{
    public interface ILogger
    {
        void LogError(string message);
        void LogInfo(string message);
    }

    // ConsoleLogger implements ILogger interface
    public class ConsoleLogger : ILogger
    {
        public void LogError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
        }

        public void LogInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
        }
    }

    // FileLogger also implements ILogger interface
    public class FileLogger : ILogger
    {
        private readonly string _path;

        public FileLogger(string path)
        {
            _path = path;
        }

        public void LogError(string message)
        {
            Log(message, "ERROR");
        }

        public void LogInfo(string message)
        {
            Log(message, "INFO");
        }

        private void Log(string message, string messageType)
        {
            // StreamWriter is not managed by CLR so to dispose the resource, use "using"
            using (var streamWriter = new StreamWriter(_path, true))
            {
                streamWriter.WriteLine(messageType + ": " + message);

            }
        }
    }

    // DbMigrator implements ILogger interface, so any class that also implements the interface
    // can be passed to DbMigrator -> dependency injection
    // the behavior of DbMigrator is EXTENDED without any modification in its code
    // --> Open/Closed principle
    // the interface is the EXTENSION POINT
    public class DbMigrator
    {
        private readonly ILogger _logger;

        // dependency injection
        // takes an instance of interface as argument instead of an object
        // specify the dependency for the DbMigrator class
        public DbMigrator(ILogger logger)
        {
            _logger = logger;
        }

        public void Migrate()
        {
            _logger.LogInfo("Migration started at " + DateTime.Now);

            // Details of Migration here

            _logger.LogInfo("Migration finished at " + DateTime.Now);
        }
    }

 


    class Program
    {
        static void Main(string[] args)
        {
            // calling DbMigrator with ConsoleLogger()
            var dbmigratorConsoleLogger = new DbMigrator(new ConsoleLogger());
            dbmigratorConsoleLogger.Migrate();

            // calling DbMigrator with FileLogger()
            var dbmigratorFileLogger = new DbMigrator(new FileLogger("C:\\Users\\i344559\\Desktop\\log.txt"));
            dbmigratorFileLogger.Migrate();

            Console.ReadKey();
        }
    }
}
