using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [ForeignKey("Status")]
        public int StatusId { get; set; }
        public virtual GeneralStatus Status { get; set; }
    }
}