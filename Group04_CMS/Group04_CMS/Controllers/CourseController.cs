using Group04_CMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Group04_CMS.Controllers
{
    public class CourseController : Controller
    {
        public ActionResult Create()
        {
            CourseModel model = new CourseModel();
            Dictionary<string, string> courseStatus = new Dictionary<string, string>();

            courseStatus.Add("Activated", "0");
            courseStatus.Add("De-activated", "1");
            courseStatus.Add("Deleted", "2");

            foreach (KeyValuePair<string, string> pair in courseStatus)
            {
                model.CourseStatusList.Add(new SelectListItem() { Text = pair.Key, Value = pair.Value, Selected = false });
            }
            return View(model);
        }
    }
}