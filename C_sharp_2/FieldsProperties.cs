/*
Fields:
- private fields start with "_" and camel case (e.g. _name)

Access Modifiers: control access to a class and/or its members
--> safety in programs

Encapsulation: 
- define fields as private (hide implmentation details)
- provide getter/setter methods as public (reveal what the class can do)

Property:
- class member that encapsulates a getter/setter for accessing a field

Indexer: 
- way to access elements in a class that represents a list of values

*/

using System;
using System.Collections.Generic;

namespace Fields
{

    public class Person{

        // Auto-implemented Property:
        // Compiler creates the private field and implements get/set automatically
        // set: private to avoid changes with calls
        public DateTime Birthdate { get; private set; }

        // 2 auto-implemented properties for name and username fields
        public string Name { get; set; }
        public string Username { get; set; }

        // setting constructor to allow birthdate set with new Person object declaration only
        public Person (DateTime birthdate){
            this.Birthdate = birthdate;
        }

        // setting property Age with a specified get method
        public int Age {
            get{
                var timeSpan = DateTime.Today - Birthdate;
                var years = timeSpan.Days/365;
                return years;
            }
        }

        /* methods used without properties
        // private field
        private DateTime _birthdate;
        
        public void SetBirthdate (DateTime birthdate){
            this._birthdate = birthdate;
        }

        public DateTime GetBirthdate(){
            return _birthdate;
        }
        */
    }

    public class Order {

    }

    public class Customer {
        public int Id;
        public string Name;
        // initilaize list - whatever constructor is used it will be initialized as empty list
        public List<Order> Orders = new List<Order>();

        // Constructor with Id
        public Customer(int id)
        {
            this.Id = id;
        }

        // Constructor with Id and Name
        public Customer(int id, string name)
            // calling previous constructor
            : this(id)
        {
            this.Name = name;
        }       

        public void Promote(){

        }
    }

    class Program
    {
        static void Main(string[] args){

            var customer = new Customer(5);
            customer.Orders.Add(new Order());
            customer.Orders.Add(new Order());

            Console.WriteLine(customer.Id);
            Console.WriteLine(customer.Orders.Count);

            /* 
            var person = new Person();
            person.SetBirthdate(new DateTime(1978, 12, 13));
            Console.WriteLine(person.GetBirthdate());
            */

            // declaring a person while creating its birthdate (from constructor)
            var person = new Person(new DateTime(1978, 12, 13));
            // calling the Age property
            Console.WriteLine(person.Age);

        }
    }
}