using System;
using System.Linq;

namespace IntegerArrayQueries
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            Console.WriteLine("Увесь масив цілих:");
            PrintArray(numbers);

            Console.WriteLine("\nПарні цілі числа:");
            PrintArray(GetEvenNumbers(numbers));

            Console.WriteLine("\nНепарні цілі числа:");
            PrintArray(GetOddNumbers(numbers));

            int threshold = 7;
            Console.WriteLine($"\nЧисла більше {threshold}:");
            PrintArray(GetNumbersGreaterThan(numbers, threshold));

            int startRange = 5;
            int endRange = 12;
            Console.WriteLine($"\nЧисла у діапазоні від {startRange} до {endRange}:");
            PrintArray(GetNumbersInRange(numbers, startRange, endRange));

            Console.WriteLine("\nЧисла, кратні семи (відсортовані за зростанням):");
            PrintArray(GetMultiplesOfSeven(numbers));

            Console.WriteLine("\nЧисла, кратні восьми (відсортовані за спаданням):");
            PrintArray(GetMultiplesOfEight(numbers));
        }

        static void PrintArray(int[] array)
        {
            foreach (var num in array)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }

        static int[] GetEvenNumbers(int[] numbers)
        {
            return numbers.Where(num => num % 2 == 0).ToArray();
        }

        static int[] GetOddNumbers(int[] numbers)
        {
            return numbers.Where(num => num % 2 != 0).ToArray();
        }

        static int[] GetNumbersGreaterThan(int[] numbers, int threshold)
        {
            return numbers.Where(num => num > threshold).ToArray();
        }

        static int[] GetNumbersInRange(int[] numbers, int startRange, int endRange)
        {
            return numbers.Where(num => num >= startRange && num <= endRange).ToArray();
        }

        static int[] GetMultiplesOfSeven(int[] numbers)
        {
            return numbers.Where(num => num % 7 == 0).OrderBy(num => num).ToArray();
        }

        static int[] GetMultiplesOfEight(int[] numbers)
        {
            return numbers.Where(num => num % 8 == 0).OrderByDescending(num => num).ToArray();
        }
    }
}
