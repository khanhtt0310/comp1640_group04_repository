using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Group04_CMS.ViewModels;

namespace Group04_CMS.Services
{
    public interface IFacultyService
    {
        List<FacultyModel> GetFaculties();
        FacultyModel AddFaculty(FacultyModel faculty);
        FacultyModel GetFacultyDetails(int id);
        FacultyModel SaveFaculty(FacultyModel item);
        ApiSimpleResult<FacultyModel> DeleteFaculty(FacultyModel item);

        // Faculty Course Management
        List<FacultyCourseModel> GetFacultyCourses();
        List<CourseModel> GetCourses();
        FacultyCourseModel AddFacultyCourse(FacultyCourseModel facultyCourse);
        FacultyCourseModel GetFacultyCourseDetails(int id);
        FacultyCourseModel SaveFacultyCourse(FacultyCourseModel item);
        ApiSimpleResult<FacultyCourseModel> DeleteFacultyCourse(FacultyCourseModel item);

        // Student Management
        List<StudentModel> GetStudents();
        StudentModel AddStudent(StudentModel queryModel);
        StudentModel GetStudentDetails(int id);
        StudentModel SaveStudent(StudentModel queryModel);
        ApiSimpleResult<StudentModel> DeleteStudent(StudentModel queryModel);

        // Student Course Management
        List<StudentCourseModel> GetStudentCourses();
        StudentCourseModel AddStudentCourse(StudentCourseModel queryModel);
        StudentCourseModel GetStudentCourseDetails(int id);
        StudentCourseModel SaveStudentCourse(StudentCourseModel queryModel);
        ApiSimpleResult<StudentCourseModel> DeleteStudentCourse(StudentCourseModel queryModel);
    }
}
