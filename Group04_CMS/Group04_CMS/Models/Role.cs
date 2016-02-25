using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Group04_CMS.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        [StringLength(255)]
        public string RoleName { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}