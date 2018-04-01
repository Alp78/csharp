/*
Access modifiers: 
- Public: accessible from anywhere
- Private: only accessible from the class

To avoid due to risk of dependencies mismatch if any update on parent class method 
(will not apply dynamically to derivated methods)
- Protected: only accessible from the class and its derived classes
- Internal: only accessible from the same assembly
- Protected Internal: only accessible from the same assembly or any derived classes
*/

using System;
using System.Collections.Generic;

namespace AccessModifiers
{


    public class Customer{
        public int Id { get; set; }
        public string Name { get; set; }

        public void Promote(){
            var rating = CalculateRating();
            if (rating == 0){
                Console.WriteLine("Promoted to 1.")
            } else {
                Console.WriteLine("Promoted to 2.")
            }
        }

        protected int CalculateRating(){
            return 0;
        }
    }

    public class GoldCustomer : Customer{
        public void OfferVoucher(){
            // parent class method accessible with Protected
            this.CalculateRating();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer();
            customer.Promote(); 

        }
    }
}