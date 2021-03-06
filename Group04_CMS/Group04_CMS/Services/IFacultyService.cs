﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Group04_CMS.Models;
using Group04_CMS.ViewModels;

namespace Group04_CMS.Services
{
    public interface IFacultyService
    {
        List<FacultyModel> GetFaculties();
        List<UserModel> GetUserByRole(string roleName);
        FacultyModel AddFaculty(FacultyModel faculty);
        FacultyModel GetFacultyDetails(int id);
        FacultyModel SaveFaculty(FacultyModel item);
        ApiSimpleResult<FacultyModel> DeleteFaculty(FacultyModel item);
        UserModel GetUserById(int id);
        
        // Faculty Course Management
        List<FacultyCourseModel> GetFacultyCourses();
        List<CourseModel> GetCourses();
        List<CourseModel> GetCoursesByAccademicSession(int id, string role);
        List<AccademicSessionModel> GetAccademicSessions();
        AccademicSessionModel GetAccademicSessionsById(int id);
        List<CourseModel> GetCoursesByUser(int id);
        FacultyCourseModel AddFacultyCourse(FacultyCourseModel facultyCourse);
        FacultyCourseModel GetFacultyCourseDetails(int id);
        FacultyCourseModel SaveFacultyCourse(FacultyCourseModel item);
        ApiSimpleResult<FacultyCourseModel> DeleteFacultyCourse(FacultyCourseModel item);
        CourseModel SaveCourse(CourseApprovalQuery item);
        string GetCourseStatus(int id);

        // Student Management
        List<StudentModel> GetStudents();
        StudentModel AddStudent(StudentModel queryModel);
        StudentModel GetStudentDetails(int id);
        StudentModel SaveStudent(StudentModel queryModel);
        ApiSimpleResult<StudentModel> DeleteStudent(StudentModel queryModel);

        // Academic Management
        List<AcademicModel> GetAcademics();
        AcademicModel AddAcademic(AcademicModel queryModel);
        AcademicModel GetAcademicDetails(int id);
        AcademicModel SaveAcademic(AcademicModel queryModel);
        ApiSimpleResult<AcademicModel> DeleteAcademic(AcademicModel queryModel);

        // Student Course Management
        List<GradeGroup> GetGradeGroups();
        List<StudentCourseModel> GetStudentCourses(int id);
        List<StudentCourseModel> GetStudentCoursesByUserId(int id);
        List<StudentCourseModel> GetAllStudentCourses();
        StudentCourseModel AddStudentCourse(StudentCourseModel queryModel);
        StudentCourseModel GetStudentCourseDetails(int id);
        StudentCourseModel SaveStudentCourse(StudentCourseModel queryModel);
        ApiSimpleResult<StudentCourseModel> DeleteStudentCourse(StudentCourseModel queryModel);
    }
}
