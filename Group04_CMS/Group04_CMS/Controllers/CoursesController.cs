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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseId,CourseCode,CourseName,CourseStatus,CourseLeaderId,CourseModeratorId")] Course course)
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
            ViewData["CourseStatusList"] = CreateCourseStatusDropdownlist();
            ViewData["CourseLeadersList"] = CreateCourseLeadersDropdownlist();
            ViewData["CourseModeratorsList"] = CreateCourseModeratorsDropdownlist();
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseId,CourseCode,CourseName,CourseStatus,CourseLeaderId,CourseModeratorId")] Course course)
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
            courseStatus.Add("Activated", "0");
            courseStatus.Add("De-activated", "1");
            courseStatus.Add("Deleted", "2");
            foreach (KeyValuePair<string, string> pair in courseStatus)
            {
                CourseStatusList.Add(new SelectListItem() { Text = pair.Key, Value = pair.Value, Selected = false });
            }
            return CourseStatusList;
        }

        protected IList<SelectListItem> CreateCourseLeadersDropdownlist()
        {
            IList<SelectListItem> CourseLeadersList = new List<SelectListItem>();
            var courseLeaders = db.Users.ToList();

            foreach (var leader in courseLeaders)
            {
                CourseLeadersList.Add(new SelectListItem() { Text = leader.UserName, Value = leader.UserId.ToString(), Selected = false });
            }
            return CourseLeadersList;
        }

        protected IList<SelectListItem> CreateCourseModeratorsDropdownlist()
        {
            IList<SelectListItem> CourseModeratorsList = new List<SelectListItem>();
            var courseModerators = db.Users.ToList();

            foreach (var leader in courseModerators)
            {
                CourseModeratorsList.Add(new SelectListItem() { Text = leader.UserName, Value = leader.UserId.ToString(), Selected = false });
            }
            return CourseModeratorsList;
        }
    }
}
