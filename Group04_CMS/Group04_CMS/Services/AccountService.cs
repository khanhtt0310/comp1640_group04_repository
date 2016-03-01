using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Group04_CMS.DAL;
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
                            select new UserModel{Id = u.UserId, UserName = u.UserName};
            if (query.Any())
            {
                results = query.ToList();
            }
            return results;
        }

        [HttpPost]
        public UserModel CreateUser(string userName, int roleId)
        {
            UserModel result = new UserModel();
            var role = db.Roles.FirstOrDefault(p => p.RoleId == roleId);
            var user = new User {UserName = userName};
            db.Users.Add(user);
            user.Roles.Add(role);
            db.SaveChanges();
            result = new UserModel
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName,
                Id = user.UserId,
                UserName = user.UserName
            };
            return result;
        }


        public List<RoleModel> GetRoles()
        {
            List<RoleModel> results = new List<RoleModel>();
            var query = from u in db.Roles
                        select new RoleModel { RoleId = u.RoleId, RoleName = u.RoleName };
            if (query.Any())
            {
                results = query.ToList();
            }
            return results;
        }

        [HttpPost]
        public RoleModel CreateRole(string roleName)
        {
            RoleModel result = new RoleModel();
            var role = new Role { RoleName = roleName };
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