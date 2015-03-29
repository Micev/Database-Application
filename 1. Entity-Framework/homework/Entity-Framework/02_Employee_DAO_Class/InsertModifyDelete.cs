namespace _02_Employee_DAO_Class
{
    using System;
    using System.Linq;

    using _01_dbContext;

    public class InsertModifyDelete
    {
        public static int insertEmployee(string fName, string mName, string lName,
                                    string jobTitle, int departamentId, int managerId,
                                    DateTime hireDate, decimal salary, int addresId){

            var db = new SoftUniEntities();

            Employee employee = new Employee{
                FirstName = fName,
                MiddleName = mName,
                LastName = lName,
                JobTitle = jobTitle,
                DepartmentID = departamentId,
                ManagerID = managerId,
                HireDate = hireDate,
                Salary = salary,
                AddressID = addresId
            };

            db.Employees.Add(employee);
            db.SaveChanges();
            Console.WriteLine("Employee with id: " + employee.EmployeeID + " was inserted");
            return employee.EmployeeID;
        }

        public static void modifyEmployee(string fName, string mName, string lName, string jobTitle, int employeeId)
        {
            SoftUniEntities db = new SoftUniEntities();

            Employee employee = db.Employees.FirstOrDefault(e => e.EmployeeID == employeeId);
            employee.FirstName = fName;
            employee.MiddleName = mName;
            employee.LastName = lName;
            employee.JobTitle = jobTitle;

            db.SaveChanges();
        }

        public static void deleteEmployee(int employeeId)
        {
            var db = new SoftUniEntities();

            Employee employee = db.Employees.FirstOrDefault(e => e.EmployeeID == employeeId);
            db.Employees.Remove(employee);
            db.SaveChanges();
            Console.WriteLine("Employee with id: " + employeeId + " was deleted");
        }

        
    }
}
