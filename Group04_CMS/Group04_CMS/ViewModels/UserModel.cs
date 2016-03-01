using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Group04_CMS.ViewModels
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}