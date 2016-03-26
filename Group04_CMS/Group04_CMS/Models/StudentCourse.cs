using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Group04_CMS.Models
{
    public class StudentCourse
    {
        [Key]
        public int StudentCourseId { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        public float Mark { get; set; }
        public int? GradeGroup { get; set; }
        [ForeignKey("GeneralStatus")]
        public int GeneralStatusId { get; set; }

        public virtual GeneralStatus GeneralStatus { get; set; }
    }
}