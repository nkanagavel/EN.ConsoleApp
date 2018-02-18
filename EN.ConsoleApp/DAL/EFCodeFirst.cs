using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EN.DataLayer.CodeFirst.Model;
using EN.DataLayer.CodeFirst;

namespace EN.ConsoleApp.DAL
{
    public class EFCodeFirst
    {
        EmployeeContext employeeContext = new EmployeeContext();
        public void InsertData()
        {
            try
            {
                Employee employee = new Employee();
                employee.EmployeeId = 1;
                employee.FirstName = "Kanagavel";
                employee.LastName = "Nagaraj";
                employee.DepartmentId = 1;

                employeeContext.Employees.Add(employee);

                employeeContext.SaveChanges();
            }
            catch (Exception ex)
            {
            }


        }

        public void DeleteData()
        {
            try { }
            catch(ApplicationException ae) { }
            catch (Exception ex)
            {

            }          
            finally { }
           
        }
    }
}
