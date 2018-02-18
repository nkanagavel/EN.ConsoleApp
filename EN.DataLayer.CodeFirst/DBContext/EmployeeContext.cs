using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EN.DataLayer.CodeFirst.Model;


namespace EN.DataLayer.CodeFirst
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext() : base("name=TestDbContext")
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

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
