

namespace _03_EmployeesWithProject
{
    using System;
    using System.Linq;

    using _01_dbContext;
    class EmployeeWithProject
    {
        public static void EmployeeWithProjectAfterYear(int year)
        {
            var db = new SoftUniEntities();

            var employees = db.Employees
                .Where(e => e.Projects.Any(p => p.StartDate.Year == year))
                .OrderBy(e => e.FirstName)
                .ToList();

            foreach (var employee in employees)
            {
                Console.WriteLine(employee.FirstName + ": ");
                foreach (var project in employee.Projects)
                {
                    Console.WriteLine("Project "+project.Name + " ,year: " + project.StartDate.Year);
                }
                Console.WriteLine();
            }
                
        }
        static void Main(string[] args)
        {
            EmployeeWithProjectAfterYear(2002);
        }
    }
}
