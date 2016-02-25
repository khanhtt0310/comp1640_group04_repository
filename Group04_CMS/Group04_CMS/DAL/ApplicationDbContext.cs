using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Group04_CMS.Models;

namespace Group04_CMS.DAL
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Course>().HasMany(c => c.Users).WithMany(i => i.Courses)
                .Map(m =>
                {
                    m.MapLeftKey("CourseId");
                    m.MapRightKey("UserId");
                    m.ToTable("CourseUser");
                });
        }
    }
}