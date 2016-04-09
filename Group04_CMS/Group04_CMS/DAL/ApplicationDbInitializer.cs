using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Group04_CMS.Models;
using Microsoft.Ajax.Utilities;

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

            context.GradeGroups.Add(new GradeGroup
            {
                Name = "Second Class"
            });

            context.GradeGroups.Add(new GradeGroup
            {
                Name = "Third Class"
            });

            context.SaveChanges();
            // Insert base Users
            #region base Users
            var adminStatus = new GeneralStatus
            {
                StatusName = "Active",
                Note = "In use",
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now
            };
            context.GeneralStatuses.Add(adminStatus);
            context.SaveChanges();
            context.Users.Add(new User
            {
                UserName = "khanhtt",
                Email = "khanhtt@gmail.com",
                StatusId = adminStatus.StatusId
            });

            var adminStatus1 = new GeneralStatus
            {
                StatusName = "Active",
                Note = "In use",
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now
            };
            context.GeneralStatuses.Add(adminStatus1);
            context.SaveChanges();
            context.Users.Add(new User
            {
                UserName = "thanhtt",
                Email = "thanhtt@gmail.com",
                StatusId = adminStatus1.StatusId
            });

            var adminStatus2 = new GeneralStatus
            {
                StatusName = "Active",
                Note = "In use",
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now
            };
            context.GeneralStatuses.Add(adminStatus2);
            context.SaveChanges();
            context.Users.Add(new User
            {
                UserName = "longtt",
                Email = "longtt@gmail.com",
                StatusId = adminStatus2.StatusId
            });

            var adminStatus3 = new GeneralStatus
            {
                StatusName = "Active",
                Note = "In use",
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now
            };
            context.GeneralStatuses.Add(adminStatus3);
            context.SaveChanges();
            context.Users.Add(new User
            {
                UserName = "linhtt",
                Email = "linhtt@gmail.com",
                StatusId = adminStatus3.StatusId
            });
            var adminStatus4 = new GeneralStatus
            {
                StatusName = "Active",
                Note = "In use",
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now
            };
            context.GeneralStatuses.Add(adminStatus4);
            context.SaveChanges();
            context.Users.Add(new User
            {
                UserName = "trungnv",
                Email = "trungnv@gmail.com",
                StatusId = adminStatus4.StatusId
            });
            var adminStatus5 = new GeneralStatus
            {
                StatusName = "Active",
                Note = "In use",
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now
            };
            context.GeneralStatuses.Add(adminStatus5);
            context.SaveChanges();
            context.Users.Add(new User
            {
                UserName = "phongnv",
                Email = "phongnv@gmail.com",
                StatusId = adminStatus5.StatusId
            });
            #endregion

            // Insert base Students
            #region base Students

            for (int i = 0; i < 40; i++)
            {
                var ststatus = new GeneralStatus
                {
                    StatusName = "Active",
                    Note = "In use",
                    CreateTime = DateTime.Now,
                    UpdateTime = DateTime.Now
                };
                context.GeneralStatuses.Add(ststatus);
                context.SaveChanges();

                context.Students.Add(new Student
                {
                    FullName = "John" + i+1,
                    StudentCode = "johngt000" + i+1,
                    PhoneNumber = "0912345678",
                    Address = "London",
                    DateOfBirth = "10/10/1990",
                    Email = "john" + i+1 + "@gmail.com",
                    GeneralStatusId = ststatus.StatusId

                });
            }
            context.SaveChanges();

            #endregion

            #region Course Info

            var fdate = DateTime.MinValue;
            DateTime.TryParse("01/01/2014", out fdate);
            var tdate = DateTime.MinValue;
            DateTime.TryParse("01/01/2015", out tdate);
            context.AccademicSessions.Add(new AccademicSession
            {
                FromDate = fdate,
                ToDate = tdate
            });
            context.SaveChanges();

            #endregion



        }
    }
}