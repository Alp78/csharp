/*
Series 2 - Exercice 1:

Design a class called Stopwatch. The job of this class is to simulate a stopwatch. It should
provide two methods: Start and Stop. We call the start method first, and the stop method next.
Then we ask the stopwatch about the duration between start and stop. Duration should be a
value in TimeSpan. Display the duration on the console.
We should also be able to use a stopwatch multiple times. So we may start and stop it and then
start and stop it again. Make sure the duration value each time is calculated properly.
We should not be able to start a stopwatch twice in a row (because that may overwrite the initial
start time). So the class should throw an InvalidOperationException if its started twice.


*/

using System;
using System.Collections.Generic;

namespace ExerciseClass
{
    public class StopWatch {
        private DateTime zero = new DateTime(2000, 01, 01);
        private DateTime start = new DateTime(2000, 01, 01);
        private DateTime end = new DateTime(2000, 01, 01);
        private TimeSpan duration = new TimeSpan(0);

        public void TimeCalculator (){
            while (true){
                Console.Write("Enter 'start', 'end' or Enter to exit: ");
                var word = Console.ReadLine();
                if ((word == "start") & (this.start == zero)){
                    this.start = DateTime.Now;
                } else if ((word == "start") & (this.start != zero)){
                    Console.WriteLine("Cannot start twice in a row!");
                } else if ((word == "end") & (this.start == zero)){
                     Console.WriteLine("Must enter 'start' first!");
                } else if ((word == "end") & (this.end == zero)){
                    this.end = DateTime.Now;
                    this.duration = this.end - this.start;
                    Console.WriteLine("Duration: {0}", this.duration);
                    if (this.end != zero) {
                        this.start = zero;
                        this.end = zero;
                    }
                } else if ((word == "end") & (this.end != zero)){
                    Console.WriteLine("Cannot end twice in a row!");
                } else if (String.IsNullOrEmpty(word)){
                    Console.WriteLine("Exit!");
                    break;
                } else{
                    Console.WriteLine("Unknown Entry!");
                }
            }
            
        }
    
        
    }

    class Program
    {
        static void Main(string[] args){
            var stopwatch = new StopWatch();
            stopwatch.TimeCalculator();
        }
    }
}