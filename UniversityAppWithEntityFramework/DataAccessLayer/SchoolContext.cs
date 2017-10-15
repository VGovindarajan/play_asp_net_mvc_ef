using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using UniversityAppWithEntityFramework.Models;

namespace UniversityAppWithEntityFramework.DataAccessLayer
{
    public class SchoolContext : DbContext
    {

        public SchoolContext() : base("SchoolContext")
        {
        }

        public DbSet<student> students { get; set; }
        public DbSet<enrollment> enrollments { get; set; }
        public DbSet<course> courses { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.HasDefaultSchema("public");
            Database.SetInitializer<SchoolContext>(null);
        }
    }
}
