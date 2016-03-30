using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Group04_CMS.Models;
using Group04_CMS.ViewModels;

namespace Group04_CMS.Services
{
    public interface IAccountService
    {
        List<UserModel> GetUsers();
        UserModel CreateUser(UserQueryModel user);
        UserModel SaveUser(UserModel user);
        UserModel GetUserDetails(int userId);
        ApiSimpleResult<UserModel> DeleteUser(UserModel user);
        List<RoleModel> GetRoles();
        RoleModel CreateRole(RoleModelQuery roleModelQuery);
        RoleModel GetRoleDetail(int roleId);
        RoleModel SaveRole(RoleModel role);
        ApiSimpleResult<RoleModel> DeleteRole(RoleModel role);
        ApiSimpleResult<UserRole> CreateUserRole(UserRoleModel userRole);
        List<UserRoleModel> GetUserRoles();
        UserRoleModel GetUserRoleDetail(int userRoleId);
        ApiSimpleResult<UserRoleModel> DeleteUserRole(UserRoleModel userRole);
        UserRoleModel SaveUserRole(UserRoleModel userRole);
    }
}
