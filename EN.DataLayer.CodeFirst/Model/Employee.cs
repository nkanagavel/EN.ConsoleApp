using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN.DataLayer.CodeFirst.Model
{
    public class Employee
    {
        //Scaller Properties
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DepartmentId { get; set; }
        //Navigation property.

        public Department Department { get; set; } 
    }
}
