using System;

namespace DI_AbstractClass

{
    // abstract class: allows to define a blueprint of class for derived classes
    // all standard methods and variables will be part of the derived classes as implemented in the abstract class
    // methods marked as abstract must be implemented in derived classes with "override" key word
    abstract class Car
    {
        // protected: accessible by the derived classes only
        protected bool _on;

        // standard method that will be part of all derived classes
        public void TurnOnOff()
        {
            _on = !_on;
            Console.WriteLine(_on ? "The car is on!" : "The car is off!");
        }

        // method marked as abstract: cannot have a body (implementation)
        // it must be defined in the derived class with "override" key word
        public abstract void Drive();
    }

    // Ferrari class is derived from Car abstract class, so it already contains the TurnOnOff() method and the _on variable.
    class Ferrari : Car
    {
        // override: needed with abstract method to override its implementation in the abstract class
        public override void Drive()
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


    class Lamborghini : Car
    {
        public override void Drive()
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
        private Car _car;

        // arg car is the dependency that we inject in Person externally
        // as it is an abstract class, all derived classes can be injected
        public Person(Car car)
        {
            _car = car;
        }

        public void Drive()
        {
            _car.TurnOnOff();
            _car.Drive();
        }
    }

    class DI_AbstractClass
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
