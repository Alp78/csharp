using System;

namespace DependencyInjection
// Dependency Injection is a Design Pattern that allows to pass dependencies in a class externally

// interface is a reference type which specifies a set of function members but it doesn't implement them
// like a contract: the classes implement the interface and must have a concrete implmentation of all function members
{
    interface ICar
    {
        // only signatures, not implementation details
        void TurnOnOff();
        void Drive();
    }


    // Ferrari class implements the ICar interface
    class Ferrari : ICar
    {
        private bool _on;
        public void TurnOnOff()
        {
            _on = !_on;
            Console.WriteLine(_on ? "The Ferrari is on!" : "The Ferrari is off!");
        }

        public void Drive()
        {
            if (_on)
            {
                Console.WriteLine("Drive Ferrari");
            }
            else
            {
                Console.WriteLine("Have to start Ferrari first!");
            }
        }
    }

    // Lamborghini class implements the ICar interface
    class Lamborghini : ICar
    {
        private bool _on;
        public void TurnOnOff()
        {
            _on = !_on;
            Console.WriteLine(_on ? "The Lamborghini is on!" : "The Lamborghini is off!");
        }

        public void Drive()
        {
            if (_on)
            {
                Console.WriteLine("Drive Lamborghini");
            }
            else
            {
                Console.WriteLine("Have to start Lamborghini first!");
            }
        }
    }

    class Person
    {
        private ICar _car;

        // arg car is the dependency that we inject in Person externally
        // as it is an interface, then all classes satisfying this interface can be injected
        public Person(ICar car)
        {
            _car = car;
        }

        public void Drive()
        {
            _car.TurnOnOff();
            _car.Drive();
        }
    }

    class DependencyInjection
    {
        static void Main(string[] args)
           
        {
            Ferrari ferrari = new Ferrari();
            Person person1 = new Person(ferrari);
            person1.Drive();

            Console.WriteLine("");
            Console.WriteLine("");

            Lamborghini lamborghini = new Lamborghini();
            Person person2 = new Person(lamborghini);
            person2.Drive();

            Console.ReadKey();
        }
    }
}
