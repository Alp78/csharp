using System;

namespace clCrawler2
{
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int EyeColor { get; set; }
        public int HairColor { get; set; }

        public Person (string FirstName, string LastName, int Age, int EyeColor, int HairColor)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Age = Age;
            this.EyeColor = EyeColor;
            this.HairColor = HairColor;
        }
    }

    class PersonBuilder
    {
        private string _firstName;
        private string _lastName;
        private int _age;
        private int _eyeColor;
        private int _hairColor;

        private void SetDefaults()
        {
            _firstName = "John";
            _lastName = "Smith";
            _age = 33;
            _eyeColor = 153;
            _hairColor = 164;
        }

        public PersonBuilder()
        {
            SetDefaults();
        }

        public PersonBuilder WithFirstName(string firstName)
        {
            _firstName = firstName;
            return this;
        }

        public PersonBuilder WithLastName(string lastName)
        {
            _lastName = lastName;
            return this;
        }

        public PersonBuilder WithAge(int age)
        {
            _age = age;
            return this;
        }

        public PersonBuilder WithEyeColor(int eyeColor)
        {
            _eyeColor = eyeColor;
            return this;
        }

        public PersonBuilder WithHairColor(int hairColor)
        {
            _hairColor = hairColor;
            return this;
        }

        public Person Build()
        {
            Person person = new Person(_firstName, _lastName, _age, _eyeColor, _hairColor);
            return person;
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new PersonBuilder().Build();

            Person person2 = new PersonBuilder().WithAge(28).WithHairColor(123).Build();

            Person person3 = new PersonBuilder().WithAge(50).WithFirstName("Arnold").WithLastName("Shwarzenegger").Build();

            Console.WriteLine(person1.FirstName);
            Console.WriteLine(person1.LastName);
            Console.WriteLine(person1.Age);
            Console.WriteLine(person1.HairColor);

            Console.WriteLine("\n\n");

            Console.WriteLine(person2.FirstName);
            Console.WriteLine(person2.LastName);
            Console.WriteLine(person2.Age);
            Console.WriteLine(person2.HairColor);

            Console.WriteLine("\n\n");

            Console.WriteLine(person3.FirstName);
            Console.WriteLine(person3.LastName);
            Console.WriteLine(person3.Age);
            Console.WriteLine(person3.HairColor);

            Console.ReadKey();
            
        }
    }
}
