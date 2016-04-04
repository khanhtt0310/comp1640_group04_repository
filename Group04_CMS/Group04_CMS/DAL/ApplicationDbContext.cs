using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using System.Web.Security;
using Group04_CMS.Models;

namespace Group04_CMS.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("Name=group04CMSConnection")
        {
            Database.SetInitializer<ApplicationDbContext>(null);
            Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        }

        public DbSet<Role> Roles { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<GeneralStatus> GeneralStatuses { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<FacultyCourse> FacultyCourses { get; set; }
        public DbSet<GradeGroup> GradeGroups { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            
        }
    }
}