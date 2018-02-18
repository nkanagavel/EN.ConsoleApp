using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EN.WebApplication.DAL
{
    public partial class UsersDbContext : DbContext
    {
        public virtual DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<UsersDbContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }

}