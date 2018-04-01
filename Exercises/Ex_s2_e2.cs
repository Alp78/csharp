/*
Series 2 Exercise 2:

Design a class called Post. This class models a StackOverflow post. It should have properties
for title, description and the date/time it was created. We should be able to up-vote or down-vote
a post. We should also be able to see the current vote value. In the main method, create a post,
up-vote and down-vote it a few times and then display the the current vote value.
In this exercise, you will learn that a StackOverflow post should provide methods for up-voting
and down-voting. You should not give the ability to set the Vote property from the outside,
because otherwise, you may accidentally change the votes of a class to 0 or to a random
number. And this is how we create bugs in our programs. The class should always protect its
state and hide its implementation detail.
*/

using System;
using System.Collections.Generic;

namespace ExerciseClass
{
    public class Post {
        private string _title;
        private string _description;
        private DateTime _creationDate = new DateTime();
        private int _votes = 0;

        public void CreatePost(string title, string description){
            this._title = title;
            this._description = description;
            this._creationDate = DateTime.Now;
        }

        public void VotePost(){
            var word = ""; 
            while (true)
            {
                word = Console.ReadLine();
                if (word == "+"){
                    this._votes += 1;
                } else if (word == "-"){
                    this._votes -= 1;
                } else if (word == "vote"){
                    Console.WriteLine("Number of votes: {0}", _votes);
                } else if (word == "date"){
                    Console.WriteLine("Creation Date: {0}", _creationDate);
                }else if (String.IsNullOrEmpty(word)){
                    Console.WriteLine("Exit!");
                    break;
                } else {
                    Console.WriteLine("Invalid entry!");
                }
            }
           
        }
    }

    class Program
    {
        static void Main(string[] args){
            var post = new Post();
            Console.Write("Enter a title: ");
            var title = Console.ReadLine();
            Console.Write("Enter a description: ");
            var description = Console.ReadLine();

            post.CreatePost(title, description);
            Console.WriteLine("Enter '+' or '-' to vote, 'vote' to display the votes, 'date' to display the date, or Enter to exit:");
            post.VotePost();
        }
    }
}