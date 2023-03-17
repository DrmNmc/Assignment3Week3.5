using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqQueries
{
    class FamousPeople
    {
        public string Name { get; set; }
        public int? BirthYear { get; set; } = null;
        public int? DeathYear { get; set; } = null;
    }

    class Program
    {
        static void Main(string[] args)
        {

        IList<FamousPeople> stemPeople = new List<FamousPeople>() {
                new FamousPeople() { Name= "Michael Faraday", BirthYear=1791,DeathYear=1867 },
                new FamousPeople() { Name= "James Clerk Maxwell", BirthYear=1831,DeathYear=1879 },
                new FamousPeople() { Name= "Marie Skłodowska Curie", BirthYear=1867,DeathYear=1934 },
                new FamousPeople() { Name= "Katherine Johnson", BirthYear=1918,DeathYear=2020 },
                new FamousPeople() { Name= "Jane C. Wright", BirthYear=1919,DeathYear=2013 },
                new FamousPeople() { Name = "Tu YouYou", BirthYear= 1930 },
                new FamousPeople() { Name = "Françoise Barré-Sinoussi", BirthYear=1947 },
                new FamousPeople() {Name = "Lydia Villa-Komaroff", BirthYear=1947},
                new FamousPeople() {Name = "Mae C. Jemison", BirthYear=1956},
                new FamousPeople() {Name = "Stephen Hawking", BirthYear=1942,DeathYear=2018 },
                new FamousPeople() {Name = "Tim Berners-Lee", BirthYear=1955 },
                new FamousPeople() {Name = "Terence Tao", BirthYear=1975 },
                new FamousPeople() {Name = "Florence Nightingale", BirthYear=1820,DeathYear=1910 },
                new FamousPeople() {Name = "George Washington Carver", DeathYear=1943 },
                new FamousPeople() {Name = "Frances Allen", BirthYear=1932,DeathYear=2020 },
                new FamousPeople() {Name = "Bill Gates", BirthYear=1955 }
     };

        //birthdates after 1900
        var query1 = from person in stemPeople
                         where person.BirthYear > 1900
                         select person;

            Console.WriteLine("People with birthdates after 1900:");
            foreach (var person in query1)
            {
                Console.WriteLine($"{person.Name}");
            }
            Console.WriteLine();

            //two lowercase L's in their name
            var query2 = from person in stemPeople
                         where person.Name.Count(c => c == 'l') == 2
                         select person;

            Console.WriteLine("People with two lowercase L's in their name:");
            foreach (var person in query2)
            {
                Console.WriteLine($"{person.Name}");
            }
            Console.WriteLine();

            //people with birthdays after 1950
            var query3 = from person in stemPeople
                         where person.BirthYear > 1950
                         select person;

            int countAfter1950 = query3.Count();
            Console.WriteLine($"Number of people with birthdays after 1950: {countAfter1950}");
            Console.WriteLine();

            //birth years between 1920 and 2000; name and count.
            var query4 = from person in stemPeople
                         where person.BirthYear >= 1920 && person.BirthYear <= 2000
                         select person;

            Console.WriteLine("People with birth years between 1920 and 2000:");
            foreach (var person in query4)
            {
                Console.WriteLine($"{person.Name}");
            }
            int birthCount = query4.Count();
            Console.WriteLine($"Count of people with birth years between 1920 and 2000: {birthCount}");
            Console.WriteLine();

            //sort by birthyear
            var query5 = from person in stemPeople
                         orderby person.BirthYear
                         select person;

            Console.WriteLine("Sorted list by BirthYear:");
            foreach (var person in query5)
            {
                Console.WriteLine($"{person.Name} - {person.BirthYear}");
            }
            Console.WriteLine();

            //sort death year 1960-2015 in asc order.
            var query6 = from person in stemPeople
                         where person.DeathYear > 1960 && person.DeathYear < 2015
                         orderby person.Name ascending
                         select person;

            Console.WriteLine("People with a death year after 1960 and before 2015 (sorted by name):");
            foreach (var person in query6)
            {
                Console.WriteLine($"{person.Name}");
            }
            Console.WriteLine();
        }
    }
}
