using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Group04_CMS.Models;
using Group04_CMS.Services;
using Group04_CMS.ViewModels;
using Microsoft.Practices.Unity;

namespace Group04_CMS.ApiControllers
{
    public class FacultyController : ApiController
    {
        [Dependency] 
        public IFacultyService FacultySvc { get; set; }
        public FacultyController() 
        {
            
        }

        public ApiSimpleResult<List<FacultyModel>> GetFaculties()
        {
            var result = new ApiSimpleResult<List<FacultyModel>>();
            var response = FacultySvc.GetFaculties();
            if (response.Any())
            {
                result.Data = response;
            }
            return result;
        }

        [HttpPost]
        public ApiSimpleResult<FacultyModel> AddFaculty(FacultyModel faculty)
        {
            var result = new ApiSimpleResult<FacultyModel>();
            var response = FacultySvc.AddFaculty(faculty);
            if (response != null)
                result.Data = response;
            return result;
        }

        public ApiSimpleResult<List<UserModel>> GetUserByRole(string id)
        {
            var result = new ApiSimpleResult<List<UserModel>>();
            var response = FacultySvc.GetUserByRole(id);
            if (response != null)
                result.Data = response;
            return result;
        }

        [HttpPost]
        public ApiSimpleResult<FacultyModel> GetFacultyDetails(int id)
        {
            var response = FacultySvc.GetFacultyDetails(id);
            var result = new ApiSimpleResult<FacultyModel>
            {
                StatusString = "Successful",
                Message = "Get all roles successfully"
            };
            if (response != null)
            {
                result.Data = response;
            }
            return result;
        }

        [HttpPost]
        public ApiSimpleResult<FacultyModel> SaveFaculty(FacultyModel faculty)
        {
            var result = new ApiSimpleResult<FacultyModel>();
            var response = FacultySvc.SaveFaculty(faculty);
            if (response != null)
                result.Data = response;
            return result;
        }

        [HttpPost]
        public ApiSimpleResult<FacultyModel> DeleteFaculty(FacultyModel faculty)
        {
            var result = new ApiSimpleResult<FacultyModel>();
            var response = FacultySvc.DeleteFaculty(faculty);
            if (response != null)
                result = response;
            return result;
        }

        // Faculty Courses Management
        public ApiSimpleResult<List<FacultyCourseModel>> GetFacultyCourses()
        {
            var result = new ApiSimpleResult<List<FacultyCourseModel>>();
            var response = FacultySvc.GetFacultyCourses();
            if (response.Any())
            {
                result.Data = response;
            }
            return result;
        }

        [HttpPost]
        public ApiSimpleResult<List<CourseModel>> GetCoursesByAccademicSession(int id)
        {
            var result = new ApiSimpleResult<List<CourseModel>>();
            var response = FacultySvc.GetCoursesByAccademicSession(id);
            if (response.Any())
            {
                result.Data = response;
            }
            return result;
        }

        public ApiSimpleResult<List<AccademicSessionModel>> GetAccademicSession()
        {
            var result = new ApiSimpleResult<List<AccademicSessionModel>>();
            var response = FacultySvc.GetAccademicSessions();
            if (response.Any())
            {
                result.Data = response;
            }
            return result;
        }

        public ApiSimpleResult<List<CourseModel>> GetCourses()
        {
            var result = new ApiSimpleResult<List<CourseModel>>();
            var response = FacultySvc.GetCourses();
            if (response.Any())
            {
                result.Data = response;
            }
            return result;
        }

        [HttpPost]
        public ApiSimpleResult<FacultyCourseModel> AddFacultyCourse(FacultyCourseModel facultyCourse)
        {
            var result = new ApiSimpleResult<FacultyCourseModel>();
            var response = FacultySvc.AddFacultyCourse(facultyCourse);
            if (response != null)
                result.Data = response;
            return result;
        }

        [HttpPost]
        public ApiSimpleResult<FacultyCourseModel> GetFacultyCourseDetails(int id)
        {
            var response = FacultySvc.GetFacultyCourseDetails(id);
            var result = new ApiSimpleResult<FacultyCourseModel>
            {
                StatusString = "Successful",
                Message = "Get all roles successfully"
            };
            if (response != null)
            {
                result.Data = response;
            }
            return result;
        }

        [HttpPost]
        public ApiSimpleResult<FacultyCourseModel> SaveFacultyCourse(FacultyCourseModel facultyCourse)
        {
            var result = new ApiSimpleResult<FacultyCourseModel>();
            var response = FacultySvc.SaveFacultyCourse(facultyCourse);
            if (response != null)
                result.Data = response;
            return result;
        }

        [HttpPost]
        public ApiSimpleResult<FacultyCourseModel> DeleteFacultyCourse(FacultyCourseModel facultyCourse)
        {
            var result = new ApiSimpleResult<FacultyCourseModel>();
            var response = FacultySvc.DeleteFacultyCourse(facultyCourse);
            if (response != null)
                result = response;
            return result;
        }

        // Student Management
        public ApiSimpleResult<List<StudentModel>> GetStudents()
        {
            var result = new ApiSimpleResult<List<StudentModel>>();
            var response = FacultySvc.GetStudents();
            if (response.Any())
            {
                result.Data = response;
            }
            return result;
        }

        [HttpPost]
        public ApiSimpleResult<StudentModel> AddStudent(StudentModel queryModel)
        {
            var result = new ApiSimpleResult<StudentModel>();
            var response = FacultySvc.AddStudent(queryModel);
            if (response != null)
                result.Data = response;
            return result;
        }

        [HttpPost]
        public ApiSimpleResult<StudentModel> GetStudentDetails(int id)
        {
            var response = FacultySvc.GetStudentDetails(id);
            var result = new ApiSimpleResult<StudentModel>
            {
                StatusString = "Successful",
                Message = "Get all roles successfully"
            };
            if (response != null)
            {
                result.Data = response;
            }
            return result;
        }

        [HttpPost]
        public ApiSimpleResult<StudentModel> SaveStudent(StudentModel queryModel)
        {
            var result = new ApiSimpleResult<StudentModel>();
            var response = FacultySvc.SaveStudent(queryModel);
            if (response != null)
                result.Data = response;
            return result;
        }

        [HttpPost]
        public ApiSimpleResult<StudentModel> DeleteStudent(StudentModel queryModel)
        {
            var result = new ApiSimpleResult<StudentModel>();
            var response = FacultySvc.DeleteStudent(queryModel);
            if (response != null)
                result = response;
            return result;
        }

        // Academic Management
        public ApiSimpleResult<List<AcademicModel>> GetAcademics()
        {
            var result = new ApiSimpleResult<List<AcademicModel>>();
            var response = FacultySvc.GetAcademics();
            if (response.Any())
            {
                result.Data = response;
            }
            return result;
        }

        [HttpPost]
        public ApiSimpleResult<AcademicModel> AddAcademic(AcademicModel queryModel)
        {
            var result = new ApiSimpleResult<AcademicModel>();
            var response = FacultySvc.AddAcademic(queryModel);
            if (response != null)
                result.Data = response;
            return result;
        }

        [HttpPost]
        public ApiSimpleResult<AcademicModel> GetAcademicDetails(int id)
        {
            var response = FacultySvc.GetAcademicDetails(id);
            var result = new ApiSimpleResult<AcademicModel>
            {
                StatusString = "Successful",
                Message = "Get all roles successfully"
            };
            if (response != null)
            {
                result.Data = response;
            }
            return result;
        }

        [HttpPost]
        public ApiSimpleResult<AcademicModel> SaveAcademic(AcademicModel queryModel)
        {
            var result = new ApiSimpleResult<AcademicModel>();
            var response = FacultySvc.SaveAcademic(queryModel);
            if (response != null)
                result.Data = response;
            return result;
        }

        [HttpPost]
        public ApiSimpleResult<AcademicModel> DeleteAcademic(AcademicModel queryModel)
        {
            var result = new ApiSimpleResult<AcademicModel>();
            var response = FacultySvc.DeleteAcademic(queryModel);
            if (response != null)
                result = response;
            return result;
        }

        [HttpPost]
        // Student Course Management
        public ApiSimpleResult<List<StudentCourseModel>> GetStudentCourses(int id)
        {
            var result = new ApiSimpleResult<List<StudentCourseModel>>();
            var response = FacultySvc.GetStudentCourses(id);
            if (response.Any())
            {
                result.Data = response;
            }
            return result;
        }

        public ApiSimpleResult<List<GradeGroup>> GetGradeGroups()
        {
            var response = FacultySvc.GetGradeGroups();
            var result = new ApiSimpleResult<List<GradeGroup>>
            {
                StatusString = "Successful",
                Message = "Get all roles successfully"
            };
            if (response != null)
            {
                result.Data = response;
            }
            return result;
        }

        [HttpPost]
        public ApiSimpleResult<StudentCourseModel> AddStudentCourse(StudentCourseModel queryModel)
        {
            var result = new ApiSimpleResult<StudentCourseModel>();
            var response = FacultySvc.AddStudentCourse(queryModel);
            if (response != null)
                result.Data = response;
            return result;
        }

        [HttpPost]
        public ApiSimpleResult<StudentCourseModel> GetStudentCourseDetails(int id)
        {
            var response = FacultySvc.GetStudentCourseDetails(id);
            var result = new ApiSimpleResult<StudentCourseModel>
            {
                StatusString = "Successful",
                Message = "Get all roles successfully"
            };
            if (response != null)
            {
                result.Data = response;
            }
            return result;
        }

        [HttpPost]
        public ApiSimpleResult<StudentCourseModel> SaveStudentCourse(StudentCourseModel queryModel)
        {
            var result = new ApiSimpleResult<StudentCourseModel>();
            var response = FacultySvc.SaveStudentCourse(queryModel);
            if (response != null)
                result.Data = response;
            return result;
        }

        [HttpPost]
        public ApiSimpleResult<StudentCourseModel> DeleteStudentCourse(StudentCourseModel queryModel)
        {
            var result = new ApiSimpleResult<StudentCourseModel>();
            var response = FacultySvc.DeleteStudentCourse(queryModel);
            if (response != null)
                result = response;
            return result;
        }
    }
}
