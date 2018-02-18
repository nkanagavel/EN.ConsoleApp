using EN.ConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN.ConsoleApp.DAL
{
    //Primary Constructor -- No Examples

    // await keyword can be used in catch and finally block.
    //catch(Exception ex) { await logger.writelog();}

    public class CSharpFeatures
    {
        List<Employee> employees = new List<Employee>();


        public CSharpFeatures()
        {
            employees.Add(new Employee() { EmployeeId = 1, EmployeeName = "Kanagavel", Skills = new List<string>() { "C#", "ASP.NET" } });
            employees.Add(new Employee() { EmployeeId = 2, EmployeeName = "Mithra", Skills = new List<string>() { "C#", "MVC" } });
            employees.Add(new Employee() { EmployeeId = 3, EmployeeName = "Suganya", Skills = new List<string>() { "DB", "Informatica" } });
        }

        //Auto-Property Initializers

        //With the Auto-Property initialization feature, the developer can initialize properties 
        //without using a private set or the need for a local variable. Following is the sample source code.
        public List<string> Roles { get; } = new List<string>() { "Manager", "Developer", "Tester" };
        public string FirstName { get; } = "Kanagavel";
        public string LastName { get; } = "N";

        //Expression Bodied Methods

        //we can create a method without the curly braces or explicit returns.
        //we can simply create an expression bodied member with only the expression
        public List<string> GetSkillByEmployeeId(int employeeId)
            => employees.Where(e => e.EmployeeId == employeeId)
            .SelectMany(e => e.Skills).ToList();

        //Conditional Access Operator
        public string GetEmployeeNameById(int employeeId)
        {
            var employee = employees.Find(i => i.EmployeeId == employeeId);
            var employeeList = employees.Where(i => i.EmployeeId == employeeId);
            return employee?.EmployeeName ?? "--";
        }

        //String Interpolation
        //In this new feature , we can directly pass variable name and expressions withing the placeholder.
        public string GetFullName() => $"The full name is {LastName}.{FirstName}";

        public bool CheckEmployeeIdExists(int employeeId)
        {
            var single = employees.Where(i => i.EmployeeId == employeeId).Select(e => e.EmployeeName).Single();
            var singleOrDefault = employees.Where(i => i.EmployeeId == employeeId).Select(e => e.EmployeeName).SingleOrDefault();
            return true;
        }

        public string GetFirstLetters()
        {
            string inputString = "Kanagavel-Sugu-Mithra-";
            var first = new string(inputString.Split('-').Select(x => x[0]).ToArray());

            //Handled Null Strings

            var first1 = new string(inputString.Split('-').Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x[0]).ToArray());
            //var emplist = new List<Employee>();
            //emplist.Add(new Employee { EmployeeName = "Kanagavel" });
            //emplist.Add(new Employee { EmployeeName = "Mithra" });

            var second = new string(employees.Select(x => x.EmployeeName[0]).ToArray());

            return string.Empty;
        }


    }

}
