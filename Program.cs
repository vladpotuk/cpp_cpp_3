using System;
using System.Collections.Generic;
using System.Linq;

namespace CityQueries
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] cities = { "Kyiv","Tokio","Rio", "Lviv", "Odessa", "Kharkiv", "Dnipro", "Zaporizhzhia", "Amsterdam", "Nairobi", "New York" };

            
            Console.WriteLine("Усі міста:");
            foreach (var city in GetCities(cities))
            {
                Console.WriteLine(city);
            }

            
            int length = 5; 
            Console.WriteLine($"\nМіста з назвою довжиною {length}:");
            foreach (var city in GetCitiesWithLength(cities, length))
            {
                Console.WriteLine(city);
            }

            
            Console.WriteLine("\nМіста, назви яких починаються з літери A:");
            foreach (var city in GetCitiesStartsWithA(cities))
            {
                Console.WriteLine(city);
            }

            
            Console.WriteLine("\nМіста, назви яких закінчуються літерою M:");
            foreach (var city in GetCitiesEndsWithM(cities))
            {
                Console.WriteLine(city);
            }

           
            Console.WriteLine("\nМіста, назви яких починаються з літери N і закінчуються літерою K:");
            foreach (var city in GetCitiesStartsWithNEndsWithK(cities))
            {
                Console.WriteLine(city);
            }

           
            Console.WriteLine("\nМіста, назви яких починаються з Ne (відсортовані за спаданням):");
            foreach (var city in GetCitiesStartsWithNeDescending(cities))
            {
                Console.WriteLine(city);
            }
        }

       
        static IEnumerable<string> GetCities(string[] cities)
        {
            return cities;
        }

        
        static IEnumerable<string> GetCitiesWithLength(string[] cities, int length)
        {
            return cities.Where(city => city.Length == length);
        }

        
        static IEnumerable<string> GetCitiesStartsWithA(string[] cities)
        {
            return cities.Where(city => city.StartsWith("A"));
        }

        
        static IEnumerable<string> GetCitiesEndsWithM(string[] cities)
        {
            return cities.Where(city => city.EndsWith("m"));
        }

        
        static IEnumerable<string> GetCitiesStartsWithNEndsWithK(string[] cities)
        {
            return cities.Where(city => city.StartsWith("N") && city.EndsWith("K"));
        }

        
        static IEnumerable<string> GetCitiesStartsWithNeDescending(string[] cities)
        {
            return cities.Where(city => city.StartsWith("Ne")).OrderByDescending(city => city);
        }
    }
}
