namespace _04_NativeSqlQuery
{
    using System;
    using System.Linq;

    using _01_dbContext;
    class Program
    {
        public static void EmployeeWithProject(int year)
        {
            var db = new SoftUniEntities();

            string nativeSQLQuery =
                "SELECT e.FirstName + ' ' + e.LastName + ' ' + p.Name + ' ' +  cast(p.StartDate as nvarchar)  " +
                "FROM Employees e " +
                "JOIN EmployeesProjects ep ON ep.EmployeeID = e.EmployeeID " +
                "JOIN Projects p on p.ProjectID = ep.ProjectID " +
                "WHERE p.StartDate >' "+ year +"-01-01' ";

            var employees = db.Database.SqlQuery<string>(nativeSQLQuery);

            foreach (var employee in employees) 
            {
                Console.WriteLine(employee);
            }


        }
        static void Main(string[] args)
        {
            EmployeeWithProject(2002);
        }
    }
}
