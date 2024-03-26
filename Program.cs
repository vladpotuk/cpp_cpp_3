using System;
using System.Collections.Generic;
using System.Linq;

public class Employee
{
    public string FullName { get; set; }
    public string Position { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public decimal Salary { get; set; }

    public override string ToString()
    {
        return $"Full Name: {FullName}, Position: {Position}, Phone Number: {PhoneNumber}, Email: {Email}, Salary: {Salary}";
    }
}

public class Company
{
    public string Name { get; set; }
    public DateTime FoundationDate { get; set; }
    public string BusinessProfile { get; set; }
    public string CEO { get; set; }
    public int EmployeesCount { get; set; }
    public string Address { get; set; }
    public List<Employee> Employees { get; set; }

    public override string ToString()
    {
        return $"Name: {Name}, Foundation Date: {FoundationDate.ToShortDateString()}, Business Profile: {BusinessProfile}, CEO: {CEO}, Employees Count: {EmployeesCount}, Address: {Address}";
    }
}

public static class CompanyExtensions
{
    
    public static IEnumerable<Employee> GetAllEmployees(this Company company)
    {
        return company.Employees;
    }

    
    public static IEnumerable<Employee> GetEmployeesWithSalaryGreaterThan(this Company company, decimal salary)
    {
        return company.Employees.Where(employee => employee.Salary > salary);
    }

    
    public static IEnumerable<Employee> GetManagers(this IEnumerable<Company> companies)
    {
        return companies.SelectMany(company => company.Employees.Where(employee => employee.Position == "Менеджер"));
    }

    
    public static IEnumerable<Employee> GetEmployeesWithPhoneNumberStartingWith(this IEnumerable<Company> companies, string prefix)
    {
        return companies.SelectMany(company => company.Employees.Where(employee => employee.PhoneNumber.StartsWith(prefix)));
    }

    
    public static IEnumerable<Employee> GetEmployeesWithEmailStartingWith(this IEnumerable<Company> companies, string prefix)
    {
        return companies.SelectMany(company => company.Employees.Where(employee => employee.Email.StartsWith(prefix)));
    }

    
    public static IEnumerable<Employee> GetEmployeesWithName(this IEnumerable<Company> companies, string name)
    {
        return companies.SelectMany(company => company.Employees.Where(employee => employee.FullName == name));
    }
}

class Program
{
    static void Main(string[] args)
    {
        
        var companies = new List<Company>
        {
            new Company
            {
                Name = "ABC Inc.",
                Employees = new List<Employee>
                {
                    new Employee { FullName = "John Doe", Position = "Developer", PhoneNumber = "234-567-8901", Email = "john@example.com", Salary = 5000 },
                    new Employee { FullName = "Alice Smith", Position = "Manager", PhoneNumber = "123-456-7890", Email = "alice@example.com", Salary = 7000 }
                }
            },
            new Company
            {
                Name = "XYZ Ltd.",
                Employees = new List<Employee>
                {
                    new Employee { FullName = "Bob Johnson", Position = "CEO", PhoneNumber = "345-678-9012", Email = "bob@example.com", Salary = 10000 },
                    new Employee { FullName = "Lionel Messi", Position = "Developer", PhoneNumber = "456-789-0123", Email = "lionel@example.com", Salary = 8000 }
                }
            }
        };

        
        foreach (var company in companies)
        {
            Console.WriteLine($"Employees of {company.Name}:");
            foreach (var employee in company.GetAllEmployees())
            {
                Console.WriteLine(employee);
            }
            Console.WriteLine();
        }

        
        decimal minSalary = 6000;
        Console.WriteLine($"Employees with salary greater than {minSalary}:");
        foreach (var company in companies)
        {
            foreach (var employee in company.GetEmployeesWithSalaryGreaterThan(minSalary))
            {
                Console.WriteLine(employee);
            }
        }

        
        Console.WriteLine("Managers:");
        foreach (var manager in companies.GetManagers())
        {
            Console.WriteLine(manager);
        }

        
        string phonePrefix = "23";
        Console.WriteLine($"Employees with phone number starting with {phonePrefix}:");
        foreach (var employee in companies.GetEmployeesWithPhoneNumberStartingWith(phonePrefix))
        {
            Console.WriteLine(employee);
        }

       
        string emailPrefix = "di";
        Console.WriteLine($"Employees with email starting with {emailPrefix}:");
        foreach (var employee in companies.GetEmployeesWithEmailStartingWith(emailPrefix))
        {
            Console.WriteLine(employee);
        }
        
        string employeeName = "Lionel Messi";
        Console.WriteLine($"Employees with name {employeeName}:");
        foreach (var employee in companies.GetEmployeesWithName(employeeName))
        {
            Console.WriteLine(employee);
        }
    }
}

