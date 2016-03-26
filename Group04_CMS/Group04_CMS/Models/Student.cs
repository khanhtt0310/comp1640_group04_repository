using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Group04_CMS.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentCode { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int StudentStatus { get; set; }
        [ForeignKey("GeneralStatus")]
        public int GeneralStatusId { get; set; }
        public virtual GeneralStatus GeneralStatus { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}