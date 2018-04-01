/*
Dependency Injection:
design pattern which allows removing dependency between different objects
through an interface

*/

using System;
using System.Collections.Generic;

namespace DependencyInjection {

    interface Ianimal{
        string GetName();
    }

    //class Wolf implements Ianimal interface
    class Wolf : Ianimal{
        public string GetName(){
            return "Wolf";
        }
    }

    //class Bear implements Ianimal interface
    class Bear : Ianimal{
        public string GetName(){
            return "Bear";
        }
    }

    // class Forest doesn't have dependency to Bear and Wolf classes, but can use their instances with injection in the program
    class Forest{
        private string _animalsOfForest;
        // Ianimal interface as parameter allows the injection of all classes implementing the interface
        public void WhoLivesInForest(Ianimal animal){
            _animalsOfForest += animal.GetName();
        }

        public string GetAnimals(){
            return _animalsOfForest;
        }
    }


    class Program {
        static void Main (string[] args) {
            Forest forest = new Forest();
            Bear bear = new Bear();
            Wolf wolf = new Wolf();

            // injection of Wolf
            forest.WhoLivesInForest(wolf);

            // injection of Bear
            forest.WhoLivesInForest(bear);   

            Console.WriteLine(forest.GetAnimals());         

        }
    }
}
