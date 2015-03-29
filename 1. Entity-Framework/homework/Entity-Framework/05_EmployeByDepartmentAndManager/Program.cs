namespace _05_EmployeByDepartmentAndManager
{
    using System;
    using System.Linq;

    using _01_dbContext;
    class Program
    {
        public static void FindEmployeeByManagerAndDepartment(string department, string managerFirstName, string managerLastName)
        {
            var db = new SoftUniEntities();

            var employees =
                from e in db.Employees
                join d in db.Departments on e.DepartmentID equals d.DepartmentID
                join m in db.Employees on e.ManagerID equals m.EmployeeID
                where d.Name == department && m.FirstName == managerFirstName && m.LastName == managerLastName
                select new
                {
                    Employee = e.FirstName + " " + e.LastName,
                    Department = d.Name,
                    Manager = m.FirstName + " " +  m.LastName
                };

            foreach(var employee in employees)
            {
                Console.WriteLine(employee);
            }

        }
        static void Main(string[] args)
        {
            FindEmployeeByManagerAndDepartment("Production", "Jo", "Brown");
        }
    }
}
