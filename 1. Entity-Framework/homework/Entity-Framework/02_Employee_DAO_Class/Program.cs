using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Employee_DAO_Class
{
    class Program
    {
        static void Main(string[] args)
        {
           var newEmployee = InsertModifyDelete.insertEmployee("Georgi", "Nikolov", "Micev", "C# Developer", 2, 1, new DateTime(2015, 03, 09), 1500, 3);

            InsertModifyDelete.deleteEmployee(294);
            InsertModifyDelete.deleteEmployee(296);
            
        }
    }
}
