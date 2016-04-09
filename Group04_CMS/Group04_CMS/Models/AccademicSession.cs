using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Group04_CMS.Models
{
    public class AccademicSession
    {
        public int AccademicSessionId { get; set; }
        public string AccSessName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}