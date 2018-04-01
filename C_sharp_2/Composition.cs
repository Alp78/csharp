/*
Coupling = measure of how interconnected classes and subsystems are
- tightly coupled: all classes are interdependent
- loosely coupled: change in a class is isolated

--> encapsulation: access modifiers
--> relationship between classes: inheritance / composition

- inheritance: kink of relationship between two classes that allows one to inherit code from the other - IS relationship
--> code reuse, polymorphic behavior

- composition: kind of relationship between two classes that allows one to contain the other - HAS relationship
*/

using System;
using System.Collections.Generic;

namespace Composition
{
    public class Logger{
        public void Log(string message){
            Console.WriteLine(message);
        }
    }
    // creating an association with the Logger class
    public class DbMigrator{
        private readonly Logger _logger;

        public DbMigrator(Logger logger){
            _logger = logger;
        }

        public void Migrate(){
            _logger.Log("Migration process.");
        }

    }

    public class Installer{
        private readonly Logger _logger;

        public Installer(Logger logger){
            _logger = logger;
        }

        public void Install(){
            _logger.Log("Installing application.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var dbMigrator = new DbMigrator(new Logger());

            var logger = new Logger();
            var installer = new Installer(logger);

            dbMigrator.Migrate();
            installer.Install();

        }
    }
}