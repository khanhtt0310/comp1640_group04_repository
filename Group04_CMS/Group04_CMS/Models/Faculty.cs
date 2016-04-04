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

        public virtual ICollection<Course> Courses { get; set; }
        public string Note { get; set; }

        [ForeignKey("Director")]
        public int DirectorId { get; set; }

        [ForeignKey("ProVice")]
        public int ProViceId { get; set; }
        public virtual User ProVice { get; set; }

        public virtual User Director { get; set; }

        [ForeignKey("GeneralStatus")]
        public int GeneralStatusId { get; set; }
        public virtual GeneralStatus GeneralStatus { get; set; }
    }
}