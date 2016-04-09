using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Group04_CMS.Services;
using Group04_CMS.ViewModels;
using Microsoft.Reporting.WebForms;

namespace Group04_CMS.Controllers
{
    public class FacultyController : Controller
    {
        [Microsoft.Practices.Unity.Dependency]
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

        public ActionResult Reports(int? id)
        {
            List<StudentCourseModel> studentCourses = FacultySvc.GetAllStudentCourses();
            List<CourseModel> courses;
            UserModel user;
            AccademicSessionModel accademic;
            if (id != null)
            {
                courses = FacultySvc.GetCoursesByAccademicSession(id.Value);
                accademic = FacultySvc.GetAccademicSessionsById(id.Value);
                user = FacultySvc.GetUserById(1);
            }
            else
            {
                courses = FacultySvc.GetCourses();
                user = FacultySvc.GetUserById(1);
                accademic = new AccademicSessionModel(){AccName = ""};
            }
            
            var totalAll = 0;
            
            DataTable dt = new DataTable("GradeDistributionDataTable");
            dt.Columns.Add("CourseName");
            dt.Columns.Add("CW0_9");
            dt.Columns.Add("CW10_19");
            dt.Columns.Add("CW20_29");
            dt.Columns.Add("CW30_39");
            dt.Columns.Add("CW40_49");
            dt.Columns.Add("CW50_59");
            dt.Columns.Add("CW60_69");
            dt.Columns.Add("CW70_79");
            dt.Columns.Add("CW80_89");
            dt.Columns.Add("CW90_100");

            var courseCode = "";
            var accademicSession = "";
            foreach (var course in courses)
            {
                courseCode += course.CourseCode + ", ";
                DataRow dr = dt.NewRow();
                dr["CourseName"] = course.CourseCode;
                var currentCourse = studentCourses.Where(x =>x.CourseId == course.CourseId);
                if (currentCourse.Any())
                {
                    var total = currentCourse.Count();
                    totalAll += total;
                    var c1 = studentCourses.Where(x => x.Mark >= 0 && x.Mark <= 9 && x.CourseId == course.CourseId).GroupBy(y => y.CourseCode).Count();
                    var c2 = studentCourses.Where(x => x.Mark >= 10 && x.Mark <= 19 && x.CourseId == course.CourseId).GroupBy(y => y.CourseCode).Count();
                    var c3 = studentCourses.Where(x => x.Mark >= 20 && x.Mark <= 29 && x.CourseId == course.CourseId).GroupBy(y => y.CourseCode).Count();
                    var c4 = studentCourses.Where(x => x.Mark >= 30 && x.Mark <= 39 && x.CourseId == course.CourseId).GroupBy(y => y.CourseCode).Count();
                    var c5 = studentCourses.Where(x => x.Mark >= 40 && x.Mark <= 49 && x.CourseId == course.CourseId).GroupBy(y => y.CourseCode).Count();
                    var c6 = studentCourses.Where(x => x.Mark >= 50 && x.Mark <= 59 && x.CourseId == course.CourseId).GroupBy(y => y.CourseCode).Count();
                    var c7 = studentCourses.Where(x => x.Mark >= 60 && x.Mark <= 69 && x.CourseId == course.CourseId).GroupBy(y => y.CourseCode).Count();
                    var c8 = studentCourses.Where(x => x.Mark >= 70 && x.Mark <= 79 && x.CourseId == course.CourseId).GroupBy(y => y.CourseCode).Count();
                    var c9 = studentCourses.Where(x => x.Mark >= 80 && x.Mark <= 89 && x.CourseId == course.CourseId).GroupBy(y => y.CourseCode).Count();
                    var c10 = studentCourses.Where(x => x.Mark >= 90 && x.CourseId == course.CourseId).GroupBy(y => y.CourseCode).Count();
                    dr["CW0_9"] = c1 * 100 / total + "%";
                    dr["CW10_19"] = c2 * 100 / total + "%";
                    dr["CW20_29"] = c3 * 100 / total + "%";
                    dr["CW30_39"] = c4 * 100 / total + "%";
                    dr["CW40_49"] = c5 * 100 / total + "%";
                    dr["CW50_59"] = c6 * 100 / total + "%";
                    dr["CW60_69"] = c7 * 100 / total + "%";
                    dr["CW70_79"] = c8 * 100 / total + "%";
                    dr["CW80_89"] = c9 * 100 / total + "%";
                    dr["CW90_100"] = c10 * 100 / total + "%";
                    dt.Rows.Add(dr);
                }
                
            }
            string reportPath = "~/Reports/CourseMonotoringReport.rdlc";

            //DataTable tblStatisticalDataTable = new DataTable("StatisticalDataTable");
            //tblStatisticalDataTable.Columns.Add("CourseName");
            //tblStatisticalDataTable.Columns.Add("CWMean");
            //tblStatisticalDataTable.Columns.Add("CWMedian");
            //tblStatisticalDataTable.Columns.Add("CWStandardDeviation");
            //tblStatisticalDataTable.Columns.Add("Overal");

            //for (int j = 0; j < 10; j++)
            //{
            //    DataRow dr = tblStatisticalDataTable.NewRow();
            //    dr[0] = "1";
            //    dr[1] = "1";
            //    dr[2] = "1";
            //    dr[3] = "1";
            //    dr[4] = "1";
            //    tblStatisticalDataTable.Rows.Add(dr);
            //}
            var title = courseCode.Remove(courseCode.Length - 2) + " Report";
            
            //set param
            List<ReportParameter> listParam = new List<ReportParameter>()
            {
                new ReportParameter("paramAccdemicSession", accademic.AccName),
                new ReportParameter("paramCourseCode", title),
                new ReportParameter("paramCourseLeader", user.UserName),
                new ReportParameter("paramStudentCount", totalAll.ToString())
            };

            ReportViewer viewer = new ReportViewer {ProcessingMode = ProcessingMode.Local};
            viewer.LocalReport.ReportPath = Server.MapPath(reportPath);
            //viewer.LocalReport.DataSources.Add(new ReportDataSource("StatisticalDataset", tblStatisticalDataTable));
            viewer.LocalReport.DataSources.Add(new ReportDataSource("GradeDistributionDataset", dt));
            viewer.LocalReport.SetParameters(listParam);
            byte[] bytes = viewer.LocalReport.Render("PDF");
            Stream stream = new MemoryStream(bytes);

            return File(stream, "application/pdf");
        }

        #endregion
    }
}