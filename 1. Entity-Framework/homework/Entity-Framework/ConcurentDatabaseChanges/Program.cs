
namespace ConcurentDatabaseChanges
{
    using System;
    using System.Linq;

    using _01_dbContext;
    using _02_Employee_DAO_Class;

    class Program
    {
        
        
        static void Main(string[] args)
        {
            var db = new SoftUniEntities();
            var SoftUniEntities = new SoftUniEntities();

            var employee = db.Employees.FirstOrDefault(e => e.JobTitle == "Stocker");
            var employee1 = SoftUniEntities.Employees.FirstOrDefault(e => e.JobTitle == "Stocker");

            Console.WriteLine(employee.JobTitle + " " + employee.FirstName + " " + employee.LastName);
            Console.WriteLine(employee1.JobTitle + " " + employee1.FirstName + " " + employee1.LastName);

            employee.JobTitle = "Saler";
            employee1.JobTitle = "Cooker";

            Console.WriteLine();

            db.SaveChanges();
            SoftUniEntities.SaveChanges();

            Console.WriteLine(employee.JobTitle + " " + employee.FirstName + " " + employee.LastName);
            Console.WriteLine(employee1.JobTitle + " " + employee1.FirstName + " " + employee1.LastName);
            

            
        }
    }
}
