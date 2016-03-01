using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Group04_CMS.Models;
using Group04_CMS.ViewModels;

namespace Group04_CMS.Services
{
    public interface IAccountService
    {
        List<UserModel> GetUsers();
        UserModel CreateUser(string userName, int roleId);
        List<RoleModel> GetRoles();
        RoleModel CreateRole(string roleName);
    }
}
