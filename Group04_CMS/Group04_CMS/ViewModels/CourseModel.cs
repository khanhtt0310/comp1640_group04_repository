using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Group04_CMS.ViewModels
{
    public class CourseModel
    {
        public int CourseId { get; set; }

        [StringLength(10)]
        public string CourseCode { get; set; }

        public string CourseName { get; set; }

        public string Status { get; set; }

        [Required]
        public IList<SelectListItem> CourseStatusList { get; set; }

        public CourseModel()
        {
            CourseStatusList = new List<SelectListItem>();
        }
    }
}