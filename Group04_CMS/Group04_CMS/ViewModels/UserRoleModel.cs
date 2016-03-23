using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Group04_CMS.Common.Global;
using Group04_CMS.Models;

namespace Group04_CMS.ViewModels
{
    public class UserRoleModel
    {
        public int UserRoleId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string UserName { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public GeneralStatus GeneralStatus { get; set; }
    }
}