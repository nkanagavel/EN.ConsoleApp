using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace EN.ConsoleApp.DAL
{
    public class DapperClass
    {

        private IDbConnection _dbconnection = new SqlConnection(ConfigurationManager.AppSettings["DapperDbConString"].ToString());

        public string GetEmployeeIdTextCommand()
        {
            var employeeId = _dbconnection.Query<string>("SELECT EmployeeId FROM [dbo].[StaffAttendance] GROUP BY EmployeeId HAVING COUNT(*) <20 order by EmployeeId").ToList<string>();

            return string.Join(",", employeeId);
        }

        public string GetEmployeeIdSP()
        {
            var employeeId = _dbconnection.Query<string>("TestStoredProcedure", new { OPR = 1 }, commandType: CommandType.StoredProcedure).ToList<string>();
            return string.Join(",", employeeId);
        }

        public bool InsertDepartmentSP()
        {
            var rowaffected = _dbconnection.Execute("TestStoredProcedure", new { OPR = 4, DepartmentName = "BPO" }, commandType: CommandType.StoredProcedure);
            return rowaffected > 1 ? true : false;
        }

        public bool InsertDepartmentComText()
        {
            string query = "INSERT INTO Department(DepartmentName) VALUES(@DepartmentName)";
            var rowaffected = _dbconnection.Execute(query, new { DepartmentName = "HR" }, commandType: CommandType.Text);
            return rowaffected > 1 ? true : false;
        }


        public bool InsertEmployeeSP()
        {
            var rowaffected = _dbconnection.Execute("TestStoredProcedure", new { OPR = 4, DepartmentName = "BPO" }, commandType: CommandType.StoredProcedure);
            return rowaffected > 1 ? true : false;
        }

        public bool InsertEmployeeComText()
        {
            string query = "INSERT INTO Employee(EmployeeName,DepartmentId) VALUES(@EmployeeName,@DepartmentId)";
            var rowaffected = _dbconnection.Execute(query, new { EmployeeName = "Suganya", DepartmentId = 3 }, commandType: CommandType.Text);
            return rowaffected > 1 ? true : false;
        }

        public List<EmployeeModel> GetEmployees()
        {
            var employees = _dbconnection.Query<EmployeeModel>("TestStoredProcedure", new { OPR = 3 }, commandType: CommandType.StoredProcedure).ToList();

            Console.WriteLine("-------------------------------------------------\n");
            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp?.EmployeeId}------{emp?.EmployeeName}---------{emp?.DepartmentName}\n");
            }
            return employees;
        }
    }

    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string DepartmentName { get; set; }
    }
}
