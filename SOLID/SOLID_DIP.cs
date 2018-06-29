/*
Dependency Inversion: high-level parts of the system should not depend on low-level parts but on abstraction
--> depend on interfaces and abstractions rather than objects and concretions
*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns
{
    public enum Relationship
    {
        Parent, Child, Sibling
    }

    public class Person
    {
        public string Name;

        public Person(string name)
        {
            Name = name;
        }
    }

    // Dependency Inversion: instead of depending on concretions, the Research class will depend on an interface (abstract)
    public interface IRelationshipBrowser
    {
        IEnumerable<Person> FindAllChildrenOf(string name);
    }

    // low-level class Relationships
    // Implementing the interface IRelationshipBrowser
    public class Relationships : IRelationshipBrowser
    {
        // List of 3 types: NuGet package "System.ValueTuple"
        private List<(Person, Relationship, Person)> relations = new List<(Person, Relationship, Person)>();

        public void AddParentAndChild(Person parent, Person child)
        {
            relations.Add((parent, Relationship.Parent, child));
            relations.Add((child, Relationship.Child, parent));
        }

        // returning a selection of Persons whose parent's name is the argument
        // --> Dependency Inversion (low-level Relationships depends on interface)
        public IEnumerable<Person> FindAllChildrenOf(string name)
        {
            // ValueTuple: Item1 (Person), Item2 (Relationship) , Item3 (Person)
            // --> find all children of parent whose name is passed as argument
            return relations.Where(x => x.Item1.Name == name && x.Item2 == Relationship.Parent).Select(relation => relation.Item3);
        }

        // exposing a public field based on private one
        public List<(Person, Relationship, Person)> Relations => relations;
    }



    // high-level class Research
    // featuring both ctors with and without dependency inversion
    public class Research
    {
        // ctor without dependency inversion: depends on concretion
        public Research(Relationships relationship)
        {
            var relations = relationship.Relations;

            // Where: from Linq
            foreach (var relation in relations.Where(x => x.Item1.Name == "Joseph" && x.Item2 == Relationship.Parent))
            {
                Console.WriteLine($"{relation.Item1.Name} has a child called {relation.Item3.Name}");
            }
        }

        // ctor with dependency inversion: depends on interface
        public Research(IRelationshipBrowser browser, string name)
        {
            foreach (var person in browser.FindAllChildrenOf(name))
            {
                Console.WriteLine($"{name} has a child called {person.Name}");
            }
        }
    }


    class Program
    {
  

        static void Main(string[] args)
        {
            Person child1 = new Person("Armand");
            Person child2 = new Person("Jeanne");
            Person parent = new Person("Joseph");

            Person child3 = new Person("Ludovic");
            Person child4 = new Person("Philippe");
            Person parent2 = new Person("Marlene");

            Relationships relationship = new Relationships();
            relationship.AddParentAndChild(parent, child1);
            relationship.AddParentAndChild(parent, child2);

            Relationships relationship2 = new Relationships();
            relationship.AddParentAndChild(parent2, child3);
            relationship.AddParentAndChild(parent2, child4);

            // calling Research ctor without dependency inversion
            new Research(relationship);

            Console.WriteLine("");

            // calling Research ctor with dependency inversion
            new Research(relationship, "Marlene");

            Console.ReadKey();
        }
    }
}
