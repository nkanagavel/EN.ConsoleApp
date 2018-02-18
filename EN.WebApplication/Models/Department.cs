using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EN.WebApplication.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
    }
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

    public class EmployeeContext : DbContext
    {
        public EmployeeContext() : base("name=TestDbContext")
        {

        }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<EmployeeContext>(null);
            //It will automatically create Insert,update,delete SP with name of EntityName_Insert or EntityName_Delete or EntityName_Update
            //modelBuilder.Entity<Employee>().MapToStoredProcedures();

            //To override the default SP name to custom SP name , parameters name will be same as entities name
            /*
            modelBuilder.Entity<Employee>().MapToStoredProcedures(p => p.Insert(x => x.HasName("InsertEmployee")));
            modelBuilder.Entity<Employee>().MapToStoredProcedures(p => p.Update(x => x.HasName("UpdateEmplolyee")));
            modelBuilder.Entity<Employee>().MapToStoredProcedures(p => p.Delete(x => x.HasName("DeleteEmployee")));
            */
            //To overrid the Parrameters name with custom name
            modelBuilder.Entity<Employee>().MapToStoredProcedures(
                p => p.Insert(x => x.HasName("InsertEmployee")
                            .Parameter(i => i.EmployeeId, "EmployeeID")
                            .Parameter(i => i.FirstName, "EmployeeFirstName")
                            .Parameter(i => i.LastName, "EmployeeLastName")
                            .Parameter(i => i.DepartmentId, "DepartmentID"))
                        .Update(x => x.HasName("UpdateEmplolyee")
                            .Parameter(i => i.EmployeeId, "EmployeeID")
                            .Parameter(i => i.FirstName, "EmployeeFirstName")
                            .Parameter(i => i.LastName, "EmployeeLastName")
                            .Parameter(i => i.DepartmentId, "DepartmentID"))
                        .Delete(x => x.HasName("DeleteEmployee")
                            .Parameter(i => i.EmployeeId, "EmployeeID"))
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}