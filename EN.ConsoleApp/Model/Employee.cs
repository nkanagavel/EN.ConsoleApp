using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN.ConsoleApp.Model
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        //public string UserName { get; }=>$"{Convert.ToString(EmployeeId)}"
        public List<string> Skills { get; set; }
    }

    public class Emp
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
    }

    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int ClientId { get; set; }
    }
    public class CategoryValue
    {
        public int CategoryValueId { get; set; }
        public string CategoryValueName { get; set; }
        public int ClientLocationId { get; set; }
    }

    public class ClientLocationMap
    {
        public int ClientId { get; set; }
        public int ClientLocationId { get; set; }
    }
}
