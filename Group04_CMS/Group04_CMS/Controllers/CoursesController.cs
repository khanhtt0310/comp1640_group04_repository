using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Group04_CMS.DAL;
using Group04_CMS.Models;

namespace Group04_CMS.Controllers
{
    public class CoursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View(db.Courses.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        public ActionResult Create()
        {
            ViewData["CourseStatusList"] = CreateCourseStatusDropdownlist();
            ViewData["CourseLeadersList"] = CreateCourseLeadersDropdownlist();
            ViewData["CourseModeratorsList"] = CreateCourseModeratorsDropdownlist();
            ViewData["AccademicSessionList"] = CreateAccademicSessionlist();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseId,CourseCode,CourseName,CourseStatus,CourseLeaderId,CourseModeratorId,AccademicSessionId")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(course);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            ViewData["CourseStatusList"] = EditCourseStatusDropdownlist();
            ViewData["CourseLeadersList"] = CreateCourseLeadersDropdownlist();
            ViewData["CourseModeratorsList"] = CreateCourseModeratorsDropdownlist();
            ViewData["AccademicSessionList"] = CreateAccademicSessionlist();
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseId,CourseCode,CourseName,CourseStatus,CourseLeaderId,CourseModeratorId,AccademicSessionId")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        protected IList<SelectListItem> CreateCourseStatusDropdownlist()
        {
            Dictionary<string, string> courseStatus = new Dictionary<string, string>();
            IList<SelectListItem> CourseStatusList = new List<SelectListItem>();
            courseStatus.Add("Active", "1");
            courseStatus.Add("Inactive", "0");
            foreach (KeyValuePair<string, string> pair in courseStatus)
            {
                CourseStatusList.Add(new SelectListItem() { Text = pair.Key, Value = pair.Value, Selected = false });
            }
            return CourseStatusList;
        }

        protected IList<SelectListItem> EditCourseStatusDropdownlist()
        {
            Dictionary<string, string> courseStatus = new Dictionary<string, string>();
            IList<SelectListItem> CourseStatusList = new List<SelectListItem>();
            courseStatus.Add("Active", "1");
            courseStatus.Add("Inactive", "0");
            courseStatus.Add("Deleted", "2");
            courseStatus.Add("Pending Approval", "3");
            courseStatus.Add("Approved", "4");
            foreach (KeyValuePair<string, string> pair in courseStatus)
            {
                CourseStatusList.Add(new SelectListItem() { Text = pair.Key, Value = pair.Value, Selected = false });
            }
            return CourseStatusList;
        }

        protected IList<SelectListItem> CreateCourseLeadersDropdownlist()
        {
            IList<SelectListItem> CourseLeadersList = new List<SelectListItem>();
            var courseLeaders = from ur in db.UserRoles
                                    join u in db.Users on ur.UserId equals u.UserId
                                    join r in db.Roles on ur.RoleId equals r.RoleId
                                    where r.RoleName == "Course Leader"
                                    select u;

            foreach (var leader in courseLeaders)
            {
                CourseLeadersList.Add(new SelectListItem() { Text = leader.UserName, Value = leader.UserId.ToString(), Selected = false });
            }
            return CourseLeadersList;
        }

        protected IList<SelectListItem> CreateAccademicSessionlist()
        {
            IList<SelectListItem> accademicSessionList = new List<SelectListItem>();
            var accs = db.AccademicSessions.ToList();

            foreach (var item in accs)
            {
                accademicSessionList.Add(new SelectListItem() { Text = item.AccSessName, Value = item.AccademicSessionId.ToString()
                    , Selected = false });
            }
            return accademicSessionList;
        }

        protected IList<SelectListItem> CreateCourseModeratorsDropdownlist()
        {
            IList<SelectListItem> CourseModeratorsList = new List<SelectListItem>();
            var courseModerators = from ur in db.UserRoles
                                   join u in db.Users on ur.UserId equals u.UserId
                                   join r in db.Roles on ur.RoleId equals r.RoleId
                                   where r.RoleName == "Course Moderator"
                                   select u;

            foreach (var leader in courseModerators)
            {
                CourseModeratorsList.Add(new SelectListItem() { Text = leader.UserName, Value = leader.UserId.ToString(), Selected = false });
            }
            return CourseModeratorsList;
        }
    }
}
