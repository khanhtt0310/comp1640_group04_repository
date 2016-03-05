using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Group04_CMS.Models
{
    public class GeneralStatus
    {
        [Key]
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public string Note { get; set; }
        public DateTimeOffset CreateTime { get; set; }
        public DateTimeOffset UpdateTime { get; set; }
        public int? CreateUserId { get; set; }
        public int? UpdateUserId { get; set; }
    }
}