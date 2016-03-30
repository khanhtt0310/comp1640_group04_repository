using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Group04_CMS.Models;

namespace Group04_CMS.ViewModels
{
    public class FacultyCourseModel
    {
        public int FacultyCourseId { get; set; }
        public int FacultyId { get; set; }
        public string FacultyName { get; set; }
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public GeneralStatus GeneralStatus { get; set; }
    }
}