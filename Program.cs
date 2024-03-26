using System;
using System.Collections.Generic;
using System.Linq;

namespace CityQueries
{
    public static class CityExtensions
    {
       
        public static IEnumerable<string> WithNameLength(this IEnumerable<string> cities, int length)
        {
            return cities.Where(city => city.Length == length);
        }

        
        public static IEnumerable<string> StartingWithLetter(this IEnumerable<string> cities, char letter)
        {
            return cities.Where(city => city.StartsWith(letter.ToString(), StringComparison.OrdinalIgnoreCase));
        }

        
        public static IEnumerable<string> EndingWithLetter(this IEnumerable<string> cities, char letter)
        {
            return cities.Where(city => city.EndsWith(letter.ToString(), StringComparison.OrdinalIgnoreCase));
        }

        
        public static IEnumerable<string> StartingWithNAndEndingWithK(this IEnumerable<string> cities)
        {
            return cities.Where(city => city.StartsWith("N", StringComparison.OrdinalIgnoreCase) && city.EndsWith("K", StringComparison.OrdinalIgnoreCase));
        }

        
        public static IEnumerable<string> StartingWithNeDescending(this IEnumerable<string> cities)
        {
            return cities.Where(city => city.StartsWith("Ne", StringComparison.OrdinalIgnoreCase)).OrderByDescending(city => city);
        }
    }

    public class CityQueries
    {
        public static void Main(string[] args)
        {
            string[] cities = { "London", "New York", "Paris", "Tokyo", "Berlin", "Madrid", "Nairobi", "Naples", "Nebraska" };

            
            Console.WriteLine("Міста з довжиною назви, що дорівнює 6:");
            foreach (var city in cities.WithNameLength(6))
            {
                Console.WriteLine(city);
            }

            
            Console.WriteLine("\nМіста, назви яких починаються з літери A:");
            foreach (var city in cities.StartingWithLetter('A'))
            {
                Console.WriteLine(city);
            }

            
            Console.WriteLine("\nМіста, назви яких закінчуються літерою M:");
            foreach (var city in cities.EndingWithLetter('M'))
            {
                Console.WriteLine(city);
            }

            
            Console.WriteLine("\nМіста, назви яких починаються з літери N і закінчуються літерою K:");
            foreach (var city in cities.StartingWithNAndEndingWithK())
            {
                Console.WriteLine(city);
            }

            
            Console.WriteLine("\nМіста, назви яких починаються з Ne, відсортовані за спаданням:");
            foreach (var city in cities.StartingWithNeDescending())
            {
                Console.WriteLine(city);
            }
        }
    }
}
