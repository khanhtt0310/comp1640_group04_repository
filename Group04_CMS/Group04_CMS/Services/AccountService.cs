using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
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
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now
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
        public UserModel GetUserDetails(int userId)
        {
            UserModel result = new UserModel();
            var users = db.Users.Where(r => r.UserId == userId);
            if (users.Any())
            {
                var user = users.First();
                result.Id = user.UserId;
                result.UserName = user.UserName;
                result.Email = user.Email;
                result.Status = user.Status;
            }
            return result;
        }

        [HttpPost]
        public HttpResponseMessage SaveUser(UserModel user)
        {
            var status = db.GeneralStatuses.Find(user.Status.StatusId);
            status.UpdateTime = DateTime.Now;
            status.StatusName = user.Status.StatusName;
            db.Entry(status).State = EntityState.Modified;
            var updateUser = db.Users.Find(user.Id);
            updateUser.UserName = user.UserName;
            updateUser.Email = user.Email;
            updateUser.Status = user.Status;
            db.Entry(updateUser).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPost]
        public ApiSimpleResult<UserModel> DeleteUser(UserModel user)
        {
            var status = db.GeneralStatuses.Find(user.Status.StatusId);
            db.Entry(status).State = EntityState.Deleted;
            var updateUser = db.Users.Find(user.RoleId);
            db.Entry(updateUser).State = EntityState.Deleted;
            var result = new ApiSimpleResult<UserModel>();
            try
            {
                db.SaveChanges();
                result.StatusString = "Successful";
                result.Message = "Delete data successfully";
                result.Data = user;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                result.Message = "Error";
                result.StatusString = "Error";
            }
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
                result.Status = role.Status.StatusName;
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
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now
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

        [HttpPost]
        public HttpResponseMessage SaveRole(RoleModel role)
        {
            var status = db.GeneralStatuses.Find(role.GeneralStatus.StatusId);
            status.UpdateTime = DateTime.Now;
            status.StatusName = role.GeneralStatus.StatusName;
            db.Entry(status).State = EntityState.Modified;
            var updateRole = db.Roles.Find(role.RoleId);
            updateRole.RoleName = role.RoleName;
            updateRole.Note = role.Note;
            db.Entry(updateRole).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPost]
        public ApiSimpleResult<RoleModel> DeleteRole(RoleModel role)
        {
            var status = db.GeneralStatuses.Find(role.GeneralStatus.StatusId);
            db.Entry(status).State = EntityState.Deleted;
            var updateRole = db.Roles.Find(role.RoleId);
            db.Entry(updateRole).State = EntityState.Deleted;
            ApiSimpleResult<RoleModel> result = new ApiSimpleResult<RoleModel>();
            try
            {
                db.SaveChanges();
                result.StatusString = "Successful";
                result.Message = "Delete data successfully";
                result.Data = role;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                result.Message = "Error";
                result.StatusString = "Error";
            }
            return result;
        }

        [HttpPost]
        public ApiSimpleResult<UserRole> CreateUserRole(UserRoleModel userRole)
        {
            var result = new ApiSimpleResult<UserRole>() { StatusString = "Fail", Message = "Cannot create user role." };
            if (userRole != null)
            {
                var status = new GeneralStatus
                {
                    StatusName = userRole.Status,
                    CreateTime = DateTime.Now,
                    UpdateTime = DateTime.Now
                };
                db.GeneralStatuses.Add(status);
                var newUserRole = new UserRole
                {
                    RoleId = userRole.RoleId,
                    UserId = userRole.UserId,
                    Note = userRole.Note,
                    StatusId = status.StatusId
                };
                db.UserRoles.Add(newUserRole);
                db.SaveChanges();
                result.StatusString = "Succesful";
                result.Message = "Create new UserRole successfully";
                result.Data = newUserRole;
            }
            return result;
        }

        public List<UserRoleModel> GetUserRoles()
        {
            List<UserRoleModel> results = new List<UserRoleModel>();
            var query = from u in db.UserRoles
                        select new UserRoleModel { UserRoleId = u.UserRoleId, RoleId = u.RoleId, RoleName = u.Role.RoleName, UserId = u.UserId, UserName = u.User.UserName, Note = u.Note };
            if (query.Any())
            {
                results = query.ToList();
            }
            return results;
        }
        public UserRoleModel GetUserRoleDetail(int userRoleId) 
        {
            UserRoleModel result = new UserRoleModel();
            var userRoles = db.UserRoles.Where(r => r.UserRoleId == userRoleId);
            if (userRoles.Any())
            {
                var userRole = userRoles.First();
                result.RoleId = userRole.RoleId;
                result.RoleName = userRole.Role.RoleName;
                result.Note = userRole.Note;
                result.UserId = userRole.UserId;
                result.UserName = userRole.User.UserName;
            }
            return result;
        }
    }
}