using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Group04_CMS.Models;

namespace Group04_CMS.ViewModels
{
    public class RoleModel
    {
        public int RoleId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Common.Global.Messages), ErrorMessageResourceName = "ValidationRequired", AllowEmptyStrings = false)]
        [StringLength(200, ErrorMessageResourceType = typeof(Common.Global.Messages), ErrorMessageResourceName = "ValidationStringLength")]
        [Display(ResourceType = typeof(Common.Global.UIString), Name = "FieldNameRole")]
        public string RoleName { get; set; }

        [Display(ResourceType = typeof(Common.Global.UIString), Name = "FieldNameStatus")]
        public string Status { get; set; }
        [Display(ResourceType = typeof(Common.Global.UIString), Name = "FieldNameNote")]
        public string Note { get; set; }

        public GeneralStatus GeneralStatus { get; set; }
    }
}