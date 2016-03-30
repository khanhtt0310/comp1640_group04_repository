using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Group04_CMS.Services;
using Group04_CMS.ViewModels;
using Microsoft.Practices.Unity;

namespace Group04_CMS.Controllers
{
    public class FacultyController : Controller
    {
        [Dependency]
        public IFacultyService FacultySvc { get; set; }
        // GET: Faculty
        #region Faculty
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult CreateFaculty()
        {
            return View();
        }

        public ActionResult EditFaculty(int id)
        {
            var model = FacultySvc.GetFacultyDetails(id);
            return View(model);
        }

        public ActionResult FacultyDetail(int id)
        {
            var model = FacultySvc.GetFacultyDetails(id);
            return View(model);
        }

        #endregion

        // Faculty Course Management
        #region Faculty Course
        public ActionResult FacultyCourse()
        {
            return View();
        }

        public ActionResult CreateFacultyCourse()
        {
            return View();
        }

        public ActionResult FacultyCourseDetail(int id)
        {
            var model = FacultySvc.GetFacultyCourseDetails(id);
            return View(model);
        }

        public ActionResult EditFacultyCourse(int id)
        {
            var model = FacultySvc.GetFacultyCourseDetails(id);
            return View(model);
        }

        #endregion
        // Student Management
        #region Student
        public ActionResult Student()
        {
            return View();
        }

        public ActionResult CreateStudent()
        {
            return View();
        }

        public ActionResult StudentDetail(int id)
        {
            var model = FacultySvc.GetStudentDetails(id);
            return View(model);
        }

        public ActionResult EditStudent(int id)
        {
            var model = FacultySvc.GetStudentDetails(id);
            return View(model);
        }

        #endregion

        // Student Course Management
        #region Student Course
        public ActionResult StudentCourse()
        {
            return View();
        }

        public ActionResult CreateStudentCourse()
        {
            return View();
        }

        public ActionResult StudentCourseDetail(int id)
        {
            var model = FacultySvc.GetStudentCourseDetails(id);
            return View(model);
        }

        public ActionResult EditStudentCourse(int id)
        {
            var model = FacultySvc.GetStudentCourseDetails(id);
            return View(model);
        }

        #endregion
    }
}