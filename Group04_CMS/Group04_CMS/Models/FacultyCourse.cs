using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace Group04_CMS.Models
{
    public class FacultyCourse
    {
        [Key]
        public int FacultyCourseId { get; set; }
        [ForeignKey("Faculty")]
        public int FacultyId { get; set; }
        public virtual Faculty Faculty { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public string Note { get; set; }
        public virtual Course Course { get; set; }
        [ForeignKey("GeneralStatus")]
        public int GeneralStatusId { get; set; }
        public virtual GeneralStatus GeneralStatus { get; set; }
    }
}