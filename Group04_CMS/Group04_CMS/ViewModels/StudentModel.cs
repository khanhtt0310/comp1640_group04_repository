using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Group04_CMS.Models;

namespace Group04_CMS.ViewModels
{
    public class StudentModel
    {
        public int StudentId { get; set; }
        public string StudentCode { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public GeneralStatus GeneralStatus { get; set; }
        public List<Course> Courses { get; set; }
    }
}