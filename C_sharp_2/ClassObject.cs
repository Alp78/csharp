/*
Visual Codes command line:
dotnet new
dotnet restore

class: building block of an app
responsible for a particular behavior

Members of a class: fields and methods
- Data -> fields (attributes)
- Behavior -> methods (functions)

Object: instance of a class (blueprint)

2 ways to declare an object of type Person:
- Person person1 = new Person();
- var person1 = new Person();

Class members:
- Instance: accessible from an object
--> person.Introduce() | person is an object of type Person

- Static: accessible from the clas
--> Console.WriteLine() | Console is the class itsel
*/

/*
Constructor:
a method that is called when an instance of a class is created
--> put an object in an early phase (initialize fields)

Constructor Overloading:
- having a method with same name but different method signature (return type, name, parameter)
--> initialization easier
--> C# compiler creates default constructors
--> only useful if pre-initialization is required
 */

using System;
using System.Collections.Generic;

namespace Classes
{
    
    public class Order
    {
        public int Id;
    }

    public class Customer
    {
        public int Id;
        public string Name;
        // field list taking Order objects
        // always initialize with empty list
        public List<Order> Orders;

        // Constructor for Orders list --> initialize the object and put it in an early state
        public Customer()
        {
            Orders = new List<Order>();
        }

        // declare a Constructor taking only 1 arg for Id
        public Customer (int id)
            : this() // this line initializes all empty contructors
        {
            this.Id = id;
        }

        // declare a Constructor taking only 1 arg for Name
        public Customer (string name)
            : this()
        {
            this.Name = name;
        }

        // another Constructor taking 2 arguments
        public Customer(int id, string name)
            : this(id) // initializes all contructors taking id as parameter
        {
            this.Name = name;
        }
    }

    public class Person
    {
        public string Name;
        public void Introduce(string to)
        {
            Console.WriteLine("Hi {0}, I am {1}", to, Name);
        }

        // Parse() returns a Person object from a string argument
        // Static: can be called from Person class --> no need to create an object first
        public static Person Parse(string name)
        {
            var person = new Person();
            person.Name = name;

            return person;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            var person = Person.Parse("Jules");
            person.Introduce("Mosh");

            // object created with the constructor in the class
            var customer = new Customer("John");
            var orders = new List<Order>();
            for (int i = 0; i < 3; i++)
            {
                orders.Add(new Order());
                orders[i].Id = i+1;
            }
            customer.Orders = orders;
            Console.WriteLine(customer.Id);
            Console.WriteLine(customer.Name);
             for (int i = 0; i < 3; i++)
            {
            Console.Write("{0} ", customer.Orders[i].Id);
            }

            Console.WriteLine("");

            // object created with an Object Initializer (rateher than with Constructors)
            var customer2 = new Customer
            // object initialization syntax
            {
                Id = 372,
                Name = "Adrian",
                Orders = new List<Order>()
            };

            for (int i = 0; i < 3; i++)
            {
                customer2.Orders.Add(new Order());
                customer2.Orders[i].Id = i+2;
            }
            Console.WriteLine(customer2.Id);
            Console.WriteLine(customer2.Name);
             for (int i = 0; i < 3; i++)
            {
            Console.Write("{0} ", customer2.Orders[i].Id);
            }
        }
    }
}