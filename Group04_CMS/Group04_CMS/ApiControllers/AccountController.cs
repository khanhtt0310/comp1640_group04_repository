using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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

        public ApiSimpleResult<RoleModel> AddRole(string roleName)
        {
            var response = AccountSvc.CreateRole(roleName);
            ApiSimpleResult<RoleModel> result = new ApiSimpleResult<RoleModel>
            {
                StatusString = "Successful",
                Message = "Create new successfully",
                Data = response
            };
            return result;
        }

        public ApiSimpleResult<UserModel> AddUser(string userName, int roleId)
        {
            var response = AccountSvc.CreateUser(userName, roleId);
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
    }
}
