using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Group04_CMS.Models;

namespace Group04_CMS.ViewModels
{
    public class StudentCourseModel
    {
        public int StudentCourseId { get; set; }
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public string StudentCode { get; set; }
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public float? Mark { get; set; }
        public string Comment { get; set; }
        public int? GradeGroupId { get; set; }
        public string GradeGroupName { get; set; }
        public string Status { get; set; }
        public int GeneralStatusId { get; set; }
        public GeneralStatus GeneralStatus { get; set; }
    }
}