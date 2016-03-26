using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Group04_CMS.Helpers;
using Group04_CMS.Models;
using Group04_CMS.Services;
using Group04_CMS.ViewModels;
using Microsoft.Practices.Unity;

namespace Group04_CMS.ApiControllers
{
    public class AccountController : ApiController
    {
        [Dependency]
        public IAccountService AccountSvc { get; set; }

        public AccountController()
        {

        }

        [HttpPost]
        public ApiSimpleResult<RoleModel> AddRole(RoleModelQuery role)
        {
            var response = AccountSvc.CreateRole(role);
            ApiSimpleResult<RoleModel> result = new ApiSimpleResult<RoleModel>
            {
                StatusString = "Successful",
                Message = "Create new successfully",
                Data = response
            };
            return result;
        }

        [HttpPost]
        public ApiSimpleResult<UserModel> GetUserDetails(int id)
        {
            var response = AccountSvc.GetUserDetails(id);
            var result = new ApiSimpleResult<UserModel>
            {
                StatusString = "Successful",
                Message = "Get all roles successfully"
            };
            if (response != null)
            {
                result.Data = response;
            }
            return result;
        }

        [HttpPost]
        public ApiSimpleResult<UserModel> AddUser(UserQueryModel user)
        {
            var response = AccountSvc.CreateUser(user);
            ApiSimpleResult<UserModel> result = new ApiSimpleResult<UserModel>
            {
                StatusString = "Successful",
                Message = "Create new successfully",
                Data = response
            };
            return result;
        }

        public ApiSimpleResult<List<UserModel>> GetUsers()
        {
            var response = AccountSvc.GetUsers();
            var result = new ApiSimpleResult<List<UserModel>>
            {
                StatusString = "Successful",
                Message = "Get all users successfully"
            };
            if (response.Any())
            {
                result.Data = response;
            }
            return result;
        }

        [HttpPost]
        public ApiSimpleResult<UserModel> DeleteUser(UserModel user)
        {
            var response = AccountSvc.DeleteUser(user);
            return response;
        }

        public ApiSimpleResult<List<RoleModel>> GetRoles()
        {
            var response = AccountSvc.GetRoles();
            var result = new ApiSimpleResult<List<RoleModel>>
            {
                StatusString = "Successful",
                Message = "Get all roles successfully"
            };
            if (response.Any())
            {
                result.Data = response;
            }
            return result;
        }

        [HttpGet]
        public ApiSimpleResult<List<GeneralStatusModel>> GetGeneralStatus()
        {
            var generalStatusList = new List<GeneralStatusModel>
            {
                new GeneralStatusModel{ StatusId = 1, StatusName = GlobalString.StatusActive },
                new GeneralStatusModel{ StatusId = 2, StatusName = GlobalString.StatusInActive }
            };
            var result = new ApiSimpleResult<List<GeneralStatusModel>>
            {
                StatusString = "Successful",
                Message = "Get all roles successfully",
                Data = generalStatusList
            };

            return result;
        }

        [HttpPost]
        public ApiSimpleResult<RoleModel> GetRoleDetails(int id)
        {
            var response = AccountSvc.GetRoleDetail(id);
            var result = new ApiSimpleResult<RoleModel>
            {
                StatusString = "Successful",
                Message = "Get all roles successfully"
            };
            if (response != null)
            {
                result.Data = response;
            }
            return result;
        }

        [HttpPost]
        public ApiSimpleResult<RoleModel> SaveRole(RoleModel role)
        {
            var response = AccountSvc.SaveRole(role);
            var result = new ApiSimpleResult<RoleModel>
            {
                StatusString = response.StatusCode.ToString(),
            };
            
            return result;
        }

        [HttpPost]
        public ApiSimpleResult<RoleModel> DeleteRole(RoleModel role)
        {
            var response = AccountSvc.DeleteRole(role);
            return response;
        }

        [HttpPost]
        public ApiSimpleResult<UserRole> AddUserRole(UserRoleModel userRole)
        {
            var response = AccountSvc.CreateUserRole(userRole);
            ApiSimpleResult<UserRole> result = new ApiSimpleResult<UserRole>
            {
                StatusString = "Successful",
                Message = "Create new successfully",
                Data = response.Data
            };
            return result;
        }

        public ApiSimpleResult<List<UserRoleModel>> GetUserRoles()
        {
            var response = AccountSvc.GetUserRoles();
            var result = new ApiSimpleResult<List<UserRoleModel>>
            {
                StatusString = "Successful",
                Message = "Get all users successfully"
            };
            if (response.Any())
            {
                result.Data = response;
            }
            return result;
        }

        [HttpPost]
        public ApiSimpleResult<UserRoleModel> GetUserRoleDetails(int id)
        {
            var response = AccountSvc.GetUserRoleDetail(id);
            var result = new ApiSimpleResult<UserRoleModel>
            {
                StatusString = "Successful",
                Message = "Get all roles successfully"
            };
            if (response != null)
            {
                result.Data = response;
            }
            return result;
        }

        [HttpPost]
        public ApiSimpleResult<UserRoleModel> DeleteUserRole(UserRoleModel userRole)
        {
            var response = AccountSvc.DeleteUserRole(userRole);
            return response;
        }

        [HttpPost]
        public ApiSimpleResult<UserRoleModel> SaveUserRole(UserRoleModel userRole)
        {
            var response = AccountSvc.SaveUserRole(userRole);
            var result = new ApiSimpleResult<UserRoleModel>
            {
                StatusString = response.StatusCode.ToString(),
            };

            return result;
        }
    }
}
