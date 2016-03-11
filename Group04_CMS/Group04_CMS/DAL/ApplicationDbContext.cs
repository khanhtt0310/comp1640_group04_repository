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
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext() :
            base("Name=group04CMSConnection")
        {
            //Configuration.ProxyCreationEnabled = false;
            //Configuration.LazyLoadingEnabled = false;

            Database.SetInitializer<ApplicationDbContext>(null);
        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<GeneralStatus> GeneralStatuses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Entity<Course>().HasMany(c => c.Users).WithMany(i => i.Courses)
                .Map(m =>
                {
                    m.MapLeftKey("CourseId");
                    m.MapRightKey("UserId");
                    m.ToTable("CourseUser");
                });
            modelBuilder.Entity<Role>().HasMany(c => c.Users).WithMany(i => i.Roles)
                .Map(m =>
                {
                    m.MapLeftKey("RoleId");
                    m.MapRightKey("UserId");
                    m.ToTable("RoleUser");
                });
            modelBuilder.Entity<User>()
                .HasRequired(c => c.Status)
                .WithMany()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Role>()
                .HasRequired(c => c.Status)
                .WithMany()
                .WillCascadeOnDelete(false);

        }
    }
}