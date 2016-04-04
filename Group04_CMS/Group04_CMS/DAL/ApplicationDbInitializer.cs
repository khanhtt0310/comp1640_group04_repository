using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Group04_CMS.Models;

namespace Group04_CMS.DAL
{
    public class ApplicationDbInitializer: System.Data.Entity.CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            base.Seed(context);
            // Insert Director role
            var generalStatus = new GeneralStatus
            {
                StatusName = "Active",
                Note = "In use",
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now
            };
            context.GeneralStatuses.Add(generalStatus);
            context.SaveChanges();

            context.Roles.Add(new Role
            {
                RoleName = "Director",
                StatusId = generalStatus.StatusId

            });

            // Insert Pro-Vice role
            var generalStatusPro = new GeneralStatus
            {
                StatusName = "Active",
                Note = "In use",
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now
            };
            context.GeneralStatuses.Add(generalStatusPro);
            context.SaveChanges();

            context.Roles.Add(new Role
            {
                RoleName = "Pro-Vice",
                StatusId = generalStatusPro.StatusId
            });

            // Insert Course Leader role
            var generalStatusCL = new GeneralStatus
            {
                StatusName = "Active",
                Note = "In use",
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now
            };
            context.GeneralStatuses.Add(generalStatusCL);
            context.SaveChanges();

            context.Roles.Add(new Role
            {
                RoleName = "Course Leader",
                StatusId = generalStatusCL.StatusId
            });

            // Insert Course Moderator role
            var generalStatusCM = new GeneralStatus
            {
                StatusName = "Active",
                Note = "In use",
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now
            };
            context.GeneralStatuses.Add(generalStatusCM);
            context.SaveChanges();

            context.Roles.Add(new Role
            {
                RoleName = "Course Moderator",
                StatusId = generalStatusCM.StatusId
            });

            context.SaveChanges();

            context.GradeGroups.Add(new GradeGroup
            {
                Name = "First Class"
            });

            context.SaveChanges();
        }
    }
}