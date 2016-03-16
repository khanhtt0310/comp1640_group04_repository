using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Group04_CMS.DAL;
using Group04_CMS.Helpers;
using Group04_CMS.Models;
using Group04_CMS.ViewModels;

namespace Group04_CMS.Services
{
    public class AccountService: IAccountService
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public List<UserModel> GetUsers()
        {
            List<UserModel> results = new List<UserModel>();
            var query = from u in db.Users
                            select new UserModel{Id = u.UserId, UserName = u.UserName, Email = u.Email, Status = u.Status };
            if (query.Any())
            {
                results = query.ToList();
            }
            return results;
        }

        [HttpPost]
        public UserModel CreateUser(UserQueryModel userQuery)
        {
            var status = new GeneralStatus
            {
                StatusName = userQuery.Status,
                CreateTime = DateTime.UtcNow,
                UpdateTime = DateTime.UtcNow
            };
            db.GeneralStatuses.Add(status);
            UserModel result = new UserModel();
            var user = new User { UserName = userQuery.UserName, Email = userQuery.Email, StatusId = status.StatusId };
            db.Users.Add(user);
            db.SaveChanges();
            result = new UserModel
            {
                Id = user.UserId,
                UserName = user.UserName,
                Email = user.Email,
                Status = user.Status
            };
            return result;
        }

        public RoleModel GetRoleDetail(int roleId)
        {
            RoleModel result = new RoleModel();
            var roles = db.Roles.Where(r => r.RoleId == roleId);
            if (roles.Any())
            {
                var role = roles.First();
                result.RoleId = role.RoleId;
                result.RoleName = role.RoleName;
                result.Note = role.Note;
                result.GeneralStatus = role.Status;
            }
            return result;
        }

        public List<RoleModel> GetRoles()
        {
            List<RoleModel> results = new List<RoleModel>();
            var query = from u in db.Roles
                        select new RoleModel { RoleId = u.RoleId, RoleName = u.RoleName, Note = u.Note, GeneralStatus = u.Status};
            if (query.Any())
            {
                results = query.ToList();
            }
            return results;
        }

        [HttpPost]
        public RoleModel CreateRole(RoleModelQuery roleModelQuery)
        {
            RoleModel result = new RoleModel();
            var status = new GeneralStatus
            {
                StatusName = roleModelQuery.Status, 
                CreateTime = DateTime.UtcNow,
                UpdateTime = DateTime.UtcNow
            };
            db.GeneralStatuses.Add(status);
            var role = new Role { RoleName = roleModelQuery.RoleName, 
                StatusId = status.StatusId,
                Note = roleModelQuery.Note
            };
            db.Roles.Add(role);
            db.SaveChanges();
            result = new RoleModel
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName,
            };
            return result;
        }
    }
}