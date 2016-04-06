using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;

namespace Group04_CMS.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        [Required]
        [StringLength(10)]
        public string CourseCode { get; set; }

        [Required]
        [StringLength(255)]
        public string CourseName { get; set; }

        [Required]
        [StringLength(1)]
        public string CourseStatus { get; set; }

        [ForeignKey("CourseLeader")]
        public int CourseLeaderId { get; set; }

        public virtual User CourseLeader { get; set; }


        [ForeignKey("CourseModerator")]
        public int CourseModeratorId { get; set; }

        public virtual User CourseModerator { get; set; }

        public int? ReportGroup { get; set; }

        public virtual ICollection<Faculty> Faculties { get; set; }
        public virtual ICollection<Student> Students { get; set; } 
    }
}