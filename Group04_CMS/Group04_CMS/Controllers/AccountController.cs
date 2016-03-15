using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Group04_CMS.ViewModels;

namespace Group04_CMS.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateRole()
        {
            return View();
        }
        public ActionResult Role()
        {
            return View();
        }
        public ActionResult RoleDetail(int roleId)
        {
            RoleModel model = new RoleModel();
            model.RoleId = roleId;
            return View(model);
        }
    }
}