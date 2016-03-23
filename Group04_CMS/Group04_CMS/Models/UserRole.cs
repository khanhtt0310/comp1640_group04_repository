using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Group04_CMS.Models
{
    public class UserRole
    {
        [Key]
        public int UserRoleId { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
        public string Note { get; set; }
        [ForeignKey("Status")]
        public int StatusId { get; set; }
        public virtual GeneralStatus Status { get; set; }
    }
}