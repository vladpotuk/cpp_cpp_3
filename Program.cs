using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentQueries
{
    public static class StudentQueries
    {
        public class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public string School { get; set; }

            public override string ToString()
            {
                return $"Name: {FirstName} {LastName}, Age: {Age}, School: {School}";
            }
        }

        public static void Main(string[] args)
        {
            Student[] students = {
                new Student { FirstName = "John", LastName = "Doe", Age = 20, School = "MIT" },
                new Student { FirstName = "Boris", LastName = "Johnson", Age = 22, School = "Oxford" },
                new Student { FirstName = "Brody", LastName = "Smith", Age = 19, School = "Harvard" },
                new Student { FirstName = "Alice", LastName = "Brown", Age = 18, School = "Stanford" },
                new Student { FirstName = "Boris", LastName = "Kovacs", Age = 21, School = "MIT" },
                new Student { FirstName = "Emma", LastName = "Watson", Age = 23, School = "Oxford" }
            };

            
            Console.WriteLine("Усі студенти:");
            foreach (var student in GetStudents(students))
            {
                Console.WriteLine(student);
            }

           
            Console.WriteLine("\nСтуденти з ім'ям Boris:");
            foreach (var student in GetStudentsWithNameBoris(students))
            {
                Console.WriteLine(student);
            }

            
            Console.WriteLine("\nСтуденти з прізвищем, яке починається з Bro:");
            foreach (var student in GetStudentsWithLastNameStartingWithBro(students))
            {
                Console.WriteLine(student);
            }

            
            Console.WriteLine("\nСтуденти, старші за 19 років:");
            foreach (var student in GetStudentsOlderThan19(students))
            {
                Console.WriteLine(student);
            }

           
            Console.WriteLine("\nСтуденти, старші за 20 років і молодші за 23 років:");
            foreach (var student in GetStudentsBetween20And23(students))
            {
                Console.WriteLine(student);
            }

            
            Console.WriteLine("\nСтуденти, які навчаються в MIT:");
            foreach (var student in GetStudentsFromMIT(students))
            {
                Console.WriteLine(student);
            }

            
            Console.WriteLine("\nСтуденти, які навчаються в Oxford, і вік яких старше 18 років (відсортовані за віком, за спаданням):");
            foreach (var student in GetStudentsFromOxfordOlderThan18Descending(students))
            {
                Console.WriteLine(student);
            }
        }

        
        public static IEnumerable<Student> GetStudents(Student[] students)
        {
            return students;
        }

        
        public static IEnumerable<Student> GetStudentsWithNameBoris(Student[] students)
        {
            return students.Where(student => student.FirstName == "Boris");
        }

        
        public static IEnumerable<Student> GetStudentsWithLastNameStartingWithBro(Student[] students)
        {
            return students.Where(student => student.LastName.StartsWith("Bro"));
        }

        
        public static IEnumerable<Student> GetStudentsOlderThan19(Student[] students)
        {
            return students.Where(student => student.Age > 19);
        }

        
        public static IEnumerable<Student> GetStudentsBetween20And23(Student[] students)
        {
            return students.Where(student => student.Age >= 20 && student.Age <= 23);
        }

        
        public static IEnumerable<Student> GetStudentsFromMIT(Student[] students)
        {
            return students.Where(student => student.School == "MIT");
        }

        
        public static IEnumerable<Student> GetStudentsFromOxfordOlderThan18Descending(Student[] students)
        {
            return students.Where(student => student.School == "Oxford" && student.Age > 18).OrderByDescending(student => student.Age);
        }
    }
}
