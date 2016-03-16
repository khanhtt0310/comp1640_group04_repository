using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Group04_CMS.Common.Global;
using Group04_CMS.Models;

namespace Group04_CMS.ViewModels
{
    public class UserRoleModel
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ValidationRequired", AllowEmptyStrings = false)]
        [Display(ResourceType = typeof(UIString), Name = "FieldNameUserId")]
        public int UserId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ValidationRequired", AllowEmptyStrings = false)]
        [Display(ResourceType = typeof(UIString), Name = "FieldNameRoleId")]
        public int RoleId { get; set; }

        [StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ValidationStringLength")]
        [Display(ResourceType = typeof(UIString), Name = "FieldNameNote")]
        [DataType(DataType.MultilineText)]
        public string Note { get; set; }

        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ValidationRequired", AllowEmptyStrings = false)]
        [Display(ResourceType = typeof(UIString), Name = "FieldNameCreateDate")]
        [DataType(DataType.Date)]
        public System.DateTimeOffset CreatedTime { get; set; }

        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ValidationRequired", AllowEmptyStrings = false)]
        [Display(ResourceType = typeof(UIString), Name = "FieldNameUpdateDate")]
        [DataType(DataType.Date)]
        public System.DateTimeOffset UpdatedTime { get; set; }


        [Display(ResourceType = typeof(UIString), Name = "FieldNameCreateBy")]
        public Nullable<int> CreatedUserId { get; set; }

        [Display(ResourceType = typeof(UIString), Name = "FieldNameUpdateBy")]
        public Nullable<int> UpdatedUserId { get; set; }

        [Display(ResourceType = typeof(UIString), Name = "FieldNameStatusId")]
        public Nullable<int> StatusId { get; set; }

        public User User { get; set; }
        public Role Role { get; set; }
        public GeneralStatus Status { get; set; }
    }
}