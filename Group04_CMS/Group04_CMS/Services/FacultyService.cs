using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using Group04_CMS.Models;
using Group04_CMS.Repositories;
using Group04_CMS.ViewModels;

namespace Group04_CMS.Services
{
    public class FacultyService: BaseRepository, IFacultyService
    {
        // Faculty Management
        #region Faculty
        public List<FacultyModel> GetFaculties()
        {
            var response = new List<FacultyModel>();
            var faculties = from f in DbContext.Faculties
                select new FacultyModel
                {
                    FacultyId = f.FacultyId,
                    FacultyName = f.FacultyName,
                    Note = f.Note,
                    Status = f.GeneralStatus.StatusName,
                    GeneralStatus = f.GeneralStatus
                };
            if (faculties.Any())
            {
                response = faculties.ToList();
            }
            
            return response;
        }

        public List<UserModel> GetUserByRole(string roleName)
        {
            var response = new List<UserModel>();
            var items = from u in DbContext.Users
                join ur in DbContext.UserRoles on u.UserId equals ur.UserId
                join r in DbContext.Roles on ur.RoleId equals r.RoleId
                where r.RoleName == roleName
                select new UserModel
                {
                    Id = u.UserId,
                    UserName = u.UserName
                };
            if (items.Any())
            {
                response = items.ToList();
            }

            return response;
        }

        public FacultyModel AddFaculty(FacultyModel faculty)
        {
            var result = new FacultyModel();
            var status = new GeneralStatus
            {
                StatusName = faculty.Status,
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now
            };
            DbContext.GeneralStatuses.Add(status);
            var newFaculty = new Faculty
            {
                FacultyName = faculty.FacultyName,
                Note = faculty.Note,
                GeneralStatusId = status.StatusId,
                DirectorId = faculty.DirectorId,
                ProViceId = faculty.ProViceId
            };
            DbContext.Faculties.Add(newFaculty);
            DbContext.SaveChanges();
            result.FacultyId = newFaculty.FacultyId;
            return result;
        }

        public FacultyModel GetFacultyDetails(int id)
        {
            var response = new FacultyModel();
            var faculty = DbContext.Faculties.Find(id);
            if (faculty != null)
            {
                response.FacultyId = faculty.FacultyId;
                response.FacultyName = faculty.FacultyName;
                response.Note = faculty.Note;
                response.Status = faculty.GeneralStatus.StatusName;
                response.GeneralStatus = faculty.GeneralStatus;
            }

            return response;
        }

        public FacultyModel SaveFaculty(FacultyModel item)
        {
            var result = new FacultyModel();
            var status = DbContext.GeneralStatuses.Find(item.GeneralStatus.StatusId);
            status.UpdateTime = DateTime.Now;
            status.StatusName = item.Status;
            DbContext.Entry(status).State = EntityState.Modified;
            var faculty = DbContext.Faculties.Find(item.FacultyId);
            if (faculty != null)
            {
                faculty.FacultyName = item.FacultyName;
                faculty.Note = item.Note;
                faculty.DirectorId = item.DirectorId;
                faculty.ProViceId = item.ProViceId;
                DbContext.Entry(faculty).State = EntityState.Modified;
            }
            try
            {
                DbContext.SaveChanges();
                result.FacultyId = item.FacultyId;
                result.FacultyName = item.FacultyName;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return null;
            }
            return result;
        }

        public ApiSimpleResult<FacultyModel> DeleteFaculty(FacultyModel item)
        {
            var status = DbContext.GeneralStatuses.Find(item.GeneralStatus.StatusId);
            DbContext.Entry(status).State = EntityState.Deleted;
            var deleteItem = DbContext.Faculties.Find(item.FacultyId);
            DbContext.Entry(deleteItem).State = EntityState.Deleted;
            var result = new ApiSimpleResult<FacultyModel>();
            try
            {
                DbContext.SaveChanges();
                result.StatusString = "Successful";
                result.Message = "Delete data successfully";
                result.Data = item;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                result.Message = "Error";
                result.StatusString = "Error";
            }
            return result;
        }
        #endregion
        // Faculty Course Management
        #region Faculty Course 
        public List<FacultyCourseModel> GetFacultyCourses()
        {
            var response = new List<FacultyCourseModel>();
            var faculties = from f in DbContext.FacultyCourses
                            select new FacultyCourseModel
                            {
                                FacultyCourseId = f.FacultyCourseId,
                                FacultyId = f.FacultyId,
                                FacultyName = f.Faculty.FacultyName,
                                CourseId = f.CourseId,
                                CourseCode = f.Course.CourseCode,
                                Note = f.Note,
                                Status = f.GeneralStatus.StatusName,
                                GeneralStatus = f.GeneralStatus
                            };
            if (faculties.Any())
            {
                response = faculties.ToList();
            }

            return response;
        }

        public List<CourseModel> GetCourses()
        {
            var response = new List<CourseModel>();
            var courses = from f in DbContext.Courses
                          select new CourseModel
                            {
                                CourseId = f.CourseId,
                                CourseCode = f.CourseCode,
                                CourseName = f.CourseName,
                                Status = f.CourseStatus
                            };
            if (courses.Any())
            {
                response = courses.ToList();
            }

            return response;
        }

        public FacultyCourseModel AddFacultyCourse(FacultyCourseModel facultyCourse)
        {
            var result = new FacultyCourseModel();
            var status = new GeneralStatus
            {
                StatusName = facultyCourse.Status,
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now
            };
            DbContext.GeneralStatuses.Add(status);
            var newItem = new FacultyCourse
            {
                FacultyId = facultyCourse.FacultyId,
                CourseId = facultyCourse.CourseId,
                Note = facultyCourse.Note,
                GeneralStatusId = status.StatusId
            };
            DbContext.FacultyCourses.Add(newItem);
            DbContext.SaveChanges();
            result.FacultyCourseId = newItem.FacultyCourseId;
            return result;
        }

        public FacultyCourseModel GetFacultyCourseDetails(int id)
        {
            var response = new FacultyCourseModel();
            var item = DbContext.FacultyCourses.Find(id);
            if (item != null)
            {
                response.FacultyCourseId = item.FacultyCourseId;
                response.FacultyId = item.FacultyId;
                response.FacultyName = item.Faculty.FacultyName;
                response.CourseCode = item.Course.CourseCode;
                response.CourseId = item.CourseId;
                response.Note = item.Note;
                response.Status = item.GeneralStatus.StatusName;
                response.GeneralStatus = item.GeneralStatus;
            }

            return response;
        }

        public FacultyCourseModel SaveFacultyCourse(FacultyCourseModel item)
        {
            var result = new FacultyCourseModel();
            var status = DbContext.GeneralStatuses.Find(item.GeneralStatus.StatusId);
            status.UpdateTime = DateTime.Now;
            status.StatusName = item.Status;
            DbContext.Entry(status).State = EntityState.Modified;
            var editItem = DbContext.FacultyCourses.Find(item.FacultyCourseId);
            if (editItem != null)
            {
                editItem.FacultyId = item.FacultyId;
                editItem.CourseId = item.CourseId;
                editItem.Note = item.Note;
                DbContext.Entry(editItem).State = EntityState.Modified;
            }
            try
            {
                DbContext.SaveChanges();
                result.FacultyCourseId = item.FacultyCourseId;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return null;
            }
            return result;
        }

        public ApiSimpleResult<FacultyCourseModel> DeleteFacultyCourse(FacultyCourseModel item)
        {
            var status = DbContext.GeneralStatuses.Find(item.GeneralStatus.StatusId);
            DbContext.Entry(status).State = EntityState.Deleted;
            var deleteItem = DbContext.FacultyCourses.Find(item.FacultyCourseId);
            DbContext.Entry(deleteItem).State = EntityState.Deleted;
            var result = new ApiSimpleResult<FacultyCourseModel>();
            try
            {
                DbContext.SaveChanges();
                result.StatusString = "Successful";
                result.Message = "Delete data successfully";
                result.Data = item;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                result.Message = "Error";
                result.StatusString = "Error";
            }
            return result;
        }

        #endregion
        // Student Management
        #region Student
        public List<StudentModel> GetStudents()
        {
            var response = new List<StudentModel>();
            var items = from instance in DbContext.Students
                            select new StudentModel
                            {
                                StudentId = instance.StudentId,
                                StudentCode = instance.StudentCode,
                                FullName = instance.FullName,
                                Address = instance.Address,
                                PhoneNumber = instance.PhoneNumber,
                                DateOfBirth = instance.DateOfBirth,
                                Email = instance.Email,
                                GeneralStatus = instance.GeneralStatus,
                                Status = instance.GeneralStatus.StatusName
                            };
            if (items.Any())
            {
                response = items.ToList();
            }

            return response;
        }

        public StudentModel AddStudent(StudentModel queryModel)
        {
            var result = new StudentModel();
            var status = new GeneralStatus
            {
                StatusName = queryModel.Status,
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now
            };
            DbContext.GeneralStatuses.Add(status);
            var newItem = new Student
            {
                StudentCode = queryModel.StudentCode,
                FullName = queryModel.FullName,
                Address = queryModel.Address,
                PhoneNumber = queryModel.PhoneNumber,
                DateOfBirth = queryModel.DateOfBirth,
                Email = queryModel.Email,
                GeneralStatusId = status.StatusId
            };
            DbContext.Students.Add(newItem);
            DbContext.SaveChanges();
            result.StudentId = newItem.StudentId;
            return result;
        }

        public StudentModel GetStudentDetails(int id)
        {
            var response = new StudentModel();
            var detailItem = DbContext.Students.Find(id);
            if (detailItem != null)
            {
                response.StudentId = detailItem.StudentId;
                response.StudentCode = detailItem.StudentCode;
                response.FullName = detailItem.FullName;
                response.Address = detailItem.Address;
                response.PhoneNumber = detailItem.PhoneNumber;
                response.DateOfBirth = detailItem.DateOfBirth;
                response.Email = detailItem.Email;
                response.GeneralStatus = detailItem.GeneralStatus;
                response.Status = detailItem.GeneralStatus.StatusName;
            }

            return response;
        }

        public StudentModel SaveStudent(StudentModel queryModel)
        {
            var result = new StudentModel();
            var status = DbContext.GeneralStatuses.Find(queryModel.GeneralStatus.StatusId);
            status.UpdateTime = DateTime.Now;
            status.StatusName = queryModel.Status;
            DbContext.Entry(status).State = EntityState.Modified;
            var editItem = DbContext.Students.Find(queryModel.StudentId);
            if (editItem != null)
            {
                editItem.StudentCode = queryModel.StudentCode;
                editItem.FullName = queryModel.FullName;
                editItem.Address = queryModel.Address;
                editItem.PhoneNumber = queryModel.PhoneNumber;
                editItem.DateOfBirth = queryModel.DateOfBirth;
                editItem.Email = queryModel.Email;
                DbContext.Entry(editItem).State = EntityState.Modified;
            }
            try
            {
                DbContext.SaveChanges();
                result.StudentId = queryModel.StudentId;
                result.StudentCode = queryModel.StudentCode;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return null;
            }
            return result;
        }

        public ApiSimpleResult<StudentModel> DeleteStudent(StudentModel queryModel)
        {
            var status = DbContext.GeneralStatuses.Find(queryModel.GeneralStatus.StatusId);
            DbContext.Entry(status).State = EntityState.Deleted;
            var deleteItem = DbContext.Students.Find(queryModel.StudentId);
            DbContext.Entry(deleteItem).State = EntityState.Deleted;
            var result = new ApiSimpleResult<StudentModel>();
            try
            {
                DbContext.SaveChanges();
                result.StatusString = "Successful";
                result.Message = "Delete data successfully";
                result.Data = queryModel;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                result.Message = "Error";
                result.StatusString = "Error";
            }
            return result;
        }

        #endregion

        // Student Course Management
        #region Student Course
        public List<StudentCourseModel> GetStudentCourses(int id)
        {
            var response = new List<StudentCourseModel>();
            var items = from instance in DbContext.StudentCourses
                        where instance.CourseId == id
                        select new StudentCourseModel
                        {
                            StudentCourseId = instance.StudentCourseId,
                            StudentId = instance.StudentId,
                            CourseId = instance.CourseId,
                            CourseCode = instance.Course.CourseCode,
                            FullName = instance.Student.FullName,
                            StudentCode = instance.Student.StudentCode,
                            Mark = instance.Mark,
                            Comment = instance.Comment,
                            GradeGroupId = instance.GradeGroup.Id,
                            GradeGroupName = instance.GradeGroup.Name,
                            GeneralStatus = instance.GeneralStatus,
                            Status = instance.GeneralStatus.StatusName
                        };
            if (items.Any())
            {
                response = items.ToList();
            }

            return response;
        }

        public List<StudentCourseModel> GetAllStudentCourses()
        {
            var response = new List<StudentCourseModel>();
            var items = from instance in DbContext.StudentCourses
                        select new StudentCourseModel
                        {
                            StudentCourseId = instance.StudentCourseId,
                            StudentId = instance.StudentId,
                            CourseId = instance.CourseId,
                            CourseCode = instance.Course.CourseCode,
                            FullName = instance.Student.FullName,
                            StudentCode = instance.Student.StudentCode,
                            Mark = instance.Mark,
                            Comment = instance.Comment,
                            GradeGroupId = instance.GradeGroup.Id,
                            GradeGroupName = instance.GradeGroup.Name,
                            GeneralStatus = instance.GeneralStatus,
                            Status = instance.GeneralStatus.StatusName
                        };
            if (items.Any())
            {
                response = items.ToList();
            }

            return response;
        }

        public List<StudentCourseModel> GetStudentCoursesByUserId(int id)
        {
            var response = new List<StudentCourseModel>();
            var items = from instance in DbContext.StudentCourses
                        where instance.CourseId == id
                        select new StudentCourseModel
                        {
                            StudentCourseId = instance.StudentCourseId,
                            StudentId = instance.StudentId,
                            CourseId = instance.CourseId,
                            CourseCode = instance.Course.CourseCode,
                            FullName = instance.Student.FullName,
                            StudentCode = instance.Student.StudentCode,
                            Mark = instance.Mark,
                            Comment = instance.Comment,
                            GradeGroupId = instance.GradeGroup.Id,
                            GradeGroupName = instance.GradeGroup.Name,
                            GeneralStatus = instance.GeneralStatus,
                            Status = instance.GeneralStatus.StatusName
                        };
            if (items.Any())
            {
                response = items.ToList();
            }

            return response;
        }

        public List<GradeGroup> GetGradeGroups()
        {
            var query = DbContext.GradeGroups;
            if (query.Any())
                return query.ToList();

            return null;
        }

        public StudentCourseModel AddStudentCourse(StudentCourseModel queryModel)
        {
            var result = new StudentCourseModel();
            var status = new GeneralStatus
            {
                StatusName = queryModel.Status,
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now
            };
            DbContext.GeneralStatuses.Add(status);
            var newItem = new StudentCourse
            {
                StudentId = queryModel.StudentId,
                CourseId = queryModel.CourseId,
                Mark = queryModel.Mark,
                Comment = queryModel.Comment,
                GradeGroupId = queryModel.GradeGroupId,
                GeneralStatusId = status.StatusId
            };
            DbContext.StudentCourses.Add(newItem);
            DbContext.SaveChanges();
            result.StudentCourseId = newItem.StudentCourseId;
            return result;
        }

        public StudentCourseModel GetStudentCourseDetails(int id)
        {
            var response = new StudentCourseModel();
            var detailItem = DbContext.StudentCourses.Find(id);
            if (detailItem != null)
            {
                response.StudentCourseId = detailItem.StudentCourseId;
                response.CourseCode = detailItem.Course.CourseCode;
                response.FullName = detailItem.Student.FullName;
                response.StudentCode = detailItem.Student.StudentCode;
                response.Mark = detailItem.Mark;
                response.Comment = detailItem.Comment;
                response.GradeGroupId = detailItem.GradeGroup.Id;
                response.GradeGroupName = detailItem.GradeGroup.Name;
                response.GeneralStatus = detailItem.GeneralStatus;
                response.Status = detailItem.GeneralStatus.StatusName;
            }

            return response;
        }

        public StudentCourseModel SaveStudentCourse(StudentCourseModel queryModel)
        {
            var result = new StudentCourseModel();
            var status = DbContext.GeneralStatuses.Find(queryModel.GeneralStatus.StatusId);
            status.UpdateTime = DateTime.Now;
            status.StatusName = queryModel.Status;
            DbContext.Entry(status).State = EntityState.Modified;
            var editItem = DbContext.StudentCourses.Find(queryModel.StudentCourseId);
            if (editItem != null)
            {
                editItem.StudentId = queryModel.StudentId;
                editItem.CourseId = queryModel.CourseId;
                editItem.Mark = queryModel.Mark;
                editItem.Comment = queryModel.Comment;
                editItem.GradeGroupId = queryModel.GradeGroupId;
                DbContext.Entry(editItem).State = EntityState.Modified;
            }
            try
            {
                DbContext.SaveChanges();
                result.StudentCourseId = queryModel.StudentCourseId;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return null;
            }
            return result;
        }

        public ApiSimpleResult<StudentCourseModel> DeleteStudentCourse(StudentCourseModel queryModel)
        {
            var status = DbContext.GeneralStatuses.Find(queryModel.GeneralStatus.StatusId);
            DbContext.Entry(status).State = EntityState.Deleted;
            var deleteItem = DbContext.StudentCourses.Find(queryModel.StudentCourseId);
            DbContext.Entry(deleteItem).State = EntityState.Deleted;
            var result = new ApiSimpleResult<StudentCourseModel>();
            try
            {
                DbContext.SaveChanges();
                result.StatusString = "Successful";
                result.Message = "Delete data successfully";
                result.Data = queryModel;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                result.Message = "Error";
                result.StatusString = "Error";
            }
            return result;
        }

        #endregion
    }
}