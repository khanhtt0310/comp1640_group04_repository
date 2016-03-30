using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Group04_CMS.Models
{
    public class GradeGroup
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}