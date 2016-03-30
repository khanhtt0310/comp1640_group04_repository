using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group04_CMS.Models
{
    public class Faculty
    {
        [Key]
        public int FacultyId { get; set; }

        [Required]
        [StringLength(255)]
        public string FacultyName { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public string Note { get; set; }

        [ForeignKey("GeneralStatus")]
        public int GeneralStatusId { get; set; }
        public virtual GeneralStatus GeneralStatus { get; set; }
    }
}