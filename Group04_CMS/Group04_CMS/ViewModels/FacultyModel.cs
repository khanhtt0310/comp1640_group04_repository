﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Group04_CMS.Models;

namespace Group04_CMS.ViewModels
{
    public class FacultyModel
    {
        public int FacultyId { get; set; }
        public string FacultyName { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public GeneralStatus GeneralStatus { get; set; }
    }
}