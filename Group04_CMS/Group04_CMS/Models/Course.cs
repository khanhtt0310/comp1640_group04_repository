﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Group04_CMS.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        [StringLength(10)]
        public string CourseCode { get; set; }

        public string CourseName { get; set; }

        [StringLength(1)]
        public string CourseStatus { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}