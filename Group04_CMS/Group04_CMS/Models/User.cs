using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Group04_CMS.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [ForeignKey("Status")]
        public int StatusId { get; set; }
        [StringLength(100)]
        public string UserName { get; set; }
        [StringLength(150)]
        public string Email { get; set; }
        [StringLength(100)]
        public string Password { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual GeneralStatus Status { get; set; }
    }
}