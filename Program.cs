using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyQueries
{
    public class Company
    {
        public string Name { get; set; }
        public DateTime FoundationDate { get; set; }
        public string BusinessProfile { get; set; }
        public string CEO { get; set; }
        public int EmployeesCount { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Foundation Date: {FoundationDate.ToShortDateString()}, Business Profile: {BusinessProfile}, CEO: {CEO}, Employees Count: {EmployeesCount}, Address: {Address}";
        }
    }

    public static class CompanyQueries
    {
        public static void Main(string[] args)
        {
            Company[] companies = {
                new Company { Name = "FoodMart", FoundationDate = new DateTime(2005, 3, 15), BusinessProfile = "Retail", CEO = "Vlad Potuk", EmployeesCount = 120, Address = "123 Main St, London" },
                new Company { Name = "Tech Solutions", FoundationDate = new DateTime(2010, 7, 20), BusinessProfile = "IT", CEO = "Aline Khodatska", EmployeesCount = 250, Address = "456 Oak St, New York" },
                new Company { Name = "MarketingPro", FoundationDate = new DateTime(2018, 5, 10), BusinessProfile = "Marketing", CEO = "Mison Kotlyar Maksim", EmployeesCount = 80, Address = "789 Elm St, London" },
                new Company { Name = "IT Innovations", FoundationDate = new DateTime(2012, 9, 5), BusinessProfile = "IT", CEO = "Vlad Cherniy", EmployeesCount = 300, Address = "101 Pine St, Chicago" },
                new Company { Name = "GreenTech", FoundationDate = new DateTime(2015, 11, 25), BusinessProfile = "Environmental", CEO = "Oleg Zamriy", EmployeesCount = 150, Address = "202 Maple St, London" }
            };

            
            Console.WriteLine("Інформація про всі фірми:");
            foreach (var company in GetAllCompanies(companies))
            {
                Console.WriteLine(company);
            }

           
            Console.WriteLine("\nФірми, які мають у назві слово \"Food\":");
            foreach (var company in GetCompaniesWithNameContainingFood(companies))
            {
                Console.WriteLine(company);
            }

            
            Console.WriteLine("\nФірми, які працюють у галузі маркетингу:");
            foreach (var company in GetMarketingCompanies(companies))
            {
                Console.WriteLine(company);
            }

            
            Console.WriteLine("\nФірми, які працюють у галузі маркетингу або IT:");
            foreach (var company in GetMarketingOrITCompanies(companies))
            {
                Console.WriteLine(company);
            }

            
            Console.WriteLine("\nФірми з кількістю працівників більшою, ніж 100:");
            foreach (var company in GetCompaniesWithMoreThan100Employees(companies))
            {
                Console.WriteLine(company);
            }

            
            Console.WriteLine("\nФірми з кількістю працівників у діапазоні від 100 до 300:");
            foreach (var company in GetCompaniesWithEmployeesBetween100And300(companies))
            {
                Console.WriteLine(company);
            }

           
            Console.WriteLine("\nФірми, які знаходяться в Лондоні:");
            foreach (var company in GetCompaniesInLondon(companies))
            {
                Console.WriteLine(company);
            }

            
            Console.WriteLine("\nФірми, в яких прізвище директора White:");
            foreach (var company in GetCompaniesWithCEONameWhite(companies))
            {
                Console.WriteLine(company);
            }

            
            Console.WriteLine("\nФірми, які засновані більше двох років тому: ");
            foreach (var company in GetCompaniesFoundedMoreThan2YearsAgo(companies))
            {
                Console.WriteLine(company);
            }

            
            Console.WriteLine("\nФірми, з дня заснування яких минуло 123 дні:");
            foreach (var company in GetCompaniesFounded123DaysAgo(companies))
            {
                Console.WriteLine(company);
            }

            
            Console.WriteLine("\nФірми, в яких прізвище директора Black і мають у назві фірми слово \"White\":");
            foreach (var company in GetCompaniesWithCEOLastNameBlackAndNameContainingWhite(companies))
            {
                Console.WriteLine(company);
            }
        }

        
        public static IEnumerable<Company> GetAllCompanies(Company[] companies)
        {
            return companies;
        }

        
        public static IEnumerable<Company> GetCompaniesWithNameContainingFood(Company[] companies)
        {
            return companies.Where(company => company.Name.Contains("Food"));
        }

        
        public static IEnumerable<Company> GetMarketingCompanies(Company[] companies)
        {
            return companies.Where(company => company.BusinessProfile == "Marketing");
        }

        
        public static IEnumerable<Company> GetMarketingOrITCompanies(Company[] companies)
        {
            return companies.Where(company => company.BusinessProfile == "Marketing" || company.BusinessProfile == "IT");
        }

       
        public static IEnumerable<Company> GetCompaniesWithMoreThan100Employees(Company[] companies)
        {
            return companies.Where(company => company.EmployeesCount > 100);
        }

        
        public static IEnumerable<Company> GetCompaniesWithEmployeesBetween100And300(Company[] companies)
        {
            return companies.Where(company => company.EmployeesCount >= 100 && company.EmployeesCount <= 300);
        }

        
        public static IEnumerable<Company> GetCompaniesInLondon(Company[] companies)
        {
            return companies.Where(company => company.Address.Contains("London"));
        }

        
        public static IEnumerable<Company> GetCompaniesWithCEONameWhite(Company[] companies)
        {
            return companies.Where(company => company.CEO.Split(' ').Last() == "White");
        }

        
        public static IEnumerable<Company> GetCompaniesFoundedMoreThan2YearsAgo(Company[] companies)
        {
            return companies.Where(company => (DateTime.Now - company.FoundationDate).TotalDays > 365 * 2);
        }

        
        public static IEnumerable<Company> GetCompaniesFounded123DaysAgo(Company[] companies)
        {
            return companies.Where(company => (DateTime.Now - company.FoundationDate).TotalDays == 123);
        }

        
        public static IEnumerable<Company> GetCompaniesWithCEOLastNameBlackAndNameContainingWhite(Company[] companies)
        {
            return companies.Where(company => company.CEO.Split(' ').Last() == "Black" && company.Name.Contains("White"));
        }
    }
}
