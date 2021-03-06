﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Group04_CMS.Services;
using Group04_CMS.ViewModels;
using Microsoft.Practices.Unity;

namespace Group04_CMS.Controllers
{
    public class AccountController : Controller
    {
        [Dependency]
        public IAccountService AccountSvc { get; set; }

        public AccountController()
        {
        }
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult EditUser(int id)
        {
            var model = AccountSvc.GetUserDetails(id);
            return View(model);
        }
        public ActionResult UserDetail(int id)
        {
            var model = AccountSvc.GetUserDetails(id);
            return View(model);
        }
        public ActionResult CreateUser()
        {
            return View();
        }
        public ActionResult UserRole()
        {
            return View();
        }
        public ActionResult CreateUserRole()
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
        public ActionResult RoleDetail(int id)
        {
            RoleModel model = AccountSvc.GetRoleDetail(id);
            return View(model);
        }
        public ActionResult EditRole(int id)
        {
            var model = AccountSvc.GetRoleDetail(id);
            return View(model);
        }
        public ActionResult UserRoleDetail(int id)
        {
            UserRoleModel model = AccountSvc.GetUserRoleDetail(id);
            return View(model);
        }
        public ActionResult EditUserRole(int id)
        {
            UserRoleModel model = AccountSvc.GetUserRoleDetail(id);
            return View(model);
        }
    }
}