using System.Linq;

namespace Link
{
    class Hobbie
    {
        public Hobbie(int id, string name)
        {
            Id = id;
            Name = Name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Hobbie[] hobbies = { new Hobbie(1, "Walking"), new Hobbie(2, "Running"), new Hobbie(3, "Trekking") };

            // lamda expression: "h" is the alias for "hobbie"
            // returns the hobbie in collection "hobbies" where the name equals Walking
            var hobbie = hobbies.Where(h => h.Name.Equals("Walking")).Select(h => h.Id);

            // same result with different syntax
            var anotherHobbie = from h in hobbies where h.Name.Equals("Walking") select h.Id; // select: what to select from the result - could be the whole object "h"

            // skips the elements of the collection before the one passed as argument
            var allHobbiesAfterFirst = hobbies.Skip(1);

            // take: skip from end count (after first one and before last one)
            var secondHobbie = hobbies.Skip(1).Take(1);

        }
    }
}
