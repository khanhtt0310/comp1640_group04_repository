using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Group04_CMS.Models;

namespace Group04_CMS.DAL
{
    public class ApplicationDbInitializer: System.Data.Entity.DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var roles = new List<Role>
            {
                new Role {RoleName = "Faculty"},
                new Role{RoleName = "Student"},
                new Role{RoleName="Admin"},
                new Role{RoleName = "Staff"}
            };
            roles.ForEach(r=>context.Roles.AddRange(roles));
            context.SaveChanges();
        }
    }
}