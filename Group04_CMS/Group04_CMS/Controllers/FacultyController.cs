using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Group04_CMS.Services;
using Group04_CMS.ViewModels;
using Microsoft.Practices.Unity;
using Microsoft.Reporting.WebForms;

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

        public ActionResult Reports(int id)
        {
            var studentCourses = FacultySvc.GetAllStudentCourses();
            string reportPath = "~/Reports/CourseMonotoringReport.rdlc";

            DataTable tblStatisticalDataTable = new DataTable("StatisticalDataTable");
            tblStatisticalDataTable.Columns.Add("CourseName");
            tblStatisticalDataTable.Columns.Add("CWMean");
            tblStatisticalDataTable.Columns.Add("CWMedian");
            tblStatisticalDataTable.Columns.Add("CWStandardDeviation");
            tblStatisticalDataTable.Columns.Add("Overal");

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
            int i = 1;
            foreach (var item in studentCourses)
            {
                DataRow dr = dt.NewRow();
                dr["CourseName"] = item.CourseCode;
                dr["CW0_9"] = (item.Mark >= 0 && item.Mark <= 9) ? item.Mark.ToString() : string.Empty;
                dr["CW10_19"] = (item.Mark >= 10 && item.Mark <= 19) ? item.Mark.ToString() : string.Empty;
                dr["CW20_29"] = (item.Mark >= 20 && item.Mark <= 29) ? item.Mark.ToString() : string.Empty;
                dr["CW30_39"] = (item.Mark >= 30 && item.Mark <= 39) ? item.Mark.ToString() : string.Empty;
                dr["CW40_49"] = (item.Mark >= 40 && item.Mark <= 49) ? item.Mark.ToString() : string.Empty;
                dr["CW50_59"] = (item.Mark >= 50 && item.Mark <= 59) ? item.Mark.ToString() : string.Empty;
                dr["CW60_69"] = (item.Mark >= 60 && item.Mark <= 69) ? item.Mark.ToString() : string.Empty;
                dr["CW70_79"] = (item.Mark >= 70 && item.Mark <= 79) ? item.Mark.ToString() : string.Empty;
                dr["CW80_89"] = (item.Mark >= 80 && item.Mark <= 89) ? item.Mark.ToString() : string.Empty;
                dr["CW90_100"] = (item.Mark >= 90 && item.Mark <= 99) ? item.Mark.ToString() : string.Empty;
                dt.Rows.Add(dr);
            }

            //set param
            List<ReportParameter> listParam = new List<ReportParameter>()
            {
                new ReportParameter("paramAccdemicSession","abcccc"),
                new ReportParameter("paramCourseCode", "CW1"),
                new ReportParameter("paramCourseLeader","AFDF"),
                new ReportParameter("paramStudentCount","120")
                //new ReportParameter("pPhieuXuat",result.SoPhieuNhap.ToString()),
                //new ReportParameter("pKhachHang",khachang),
                //new ReportParameter("pDiaChiKhachHang",diachi),
                //new ReportParameter("pNhanVien",result.CreatedBy.TenDayDu),
                //new ReportParameter("pDienGiai",result.DienGiai),
                //new ReportParameter("pTongTienHang",tongtienhang.ToString("#,##0")),
                //new ReportParameter("pVAT",result.VAT.ToString("#,##0")),
                //new ReportParameter("pNoCu",nocu.ToString("#,##0")),
                //new ReportParameter("pTongTien",(nocu + result.TongTien).ToString("#,##0")),
                //new ReportParameter("pDaTra",result.DaTra.ToString("#,##0")),                
                //new ReportParameter("pConNo",(result.TongTien + nocu - result.DaTra).ToString("#,##0"))
            };

            DataSet ds = new DataSet("CourseMonitoringReport");
            ds.Tables.Add(tblStatisticalDataTable);
            ds.Tables.Add(dt);

            ReportViewer viewer = new ReportViewer();
            viewer.ProcessingMode = ProcessingMode.Local;
            viewer.LocalReport.ReportPath = Server.MapPath(reportPath);
            viewer.LocalReport.DataSources.Add(new ReportDataSource("StatisticalDataset", tblStatisticalDataTable));
            viewer.LocalReport.DataSources.Add(new ReportDataSource("GradeDistributionDataset", dt));
            viewer.LocalReport.SetParameters(listParam);
            byte[] bytes = viewer.LocalReport.Render("PDF");
            Stream stream = new MemoryStream(bytes);

            return File(stream, "application/pdf");
        }

        #endregion
    }
}