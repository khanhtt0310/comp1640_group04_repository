cmsApp.controller('facultyController', ['$scope', 'facultyService', '$window', function ($scope, facultyService, $window) {
    $scope.currentFaculty = {};
    $scope.faculties = [];
    $scope.disabled = false;

    $scope.getFaculties = function() {
        facultyService.getFaculties().success(function(response) {
            $scope.faculties = response.Data;
        });
    };

    // get status
    $scope.statusData = [{ "StatusId": 1, "StatusName": "Active" }, { "StatusId": 2, "StatusName": "Inactive" }];

    $scope.addFaculty = function () {
        $scope.FacultyId = 0;
        var faculty = {
            FacultyId: $scope.FacultyId,
            FacultyName: $scope.FacultyName,
            Note: $scope.Note,
            DirectorId: $scope.selectedDirector,
            ProViceId: $scope.selectedProVice
        };
        facultyService.createFaculty(faculty).success(function (response) {
            if (response != null && response.Data != null) {
                debugger;
                $scope.currentFaculty = response.Data;
                $window.location.href = '/Faculty/Index';
            }
        });
    };

    $scope.directorData = [];
    $scope.getDirectors = function () {
        var roleName = "Director";
        facultyService.getUserByRole(roleName).success(function (response) {
            if (response != null && response.Data != null) {
                $scope.directorData = response.Data;
            }
        });
    };

    $scope.proViceData = [];
    $scope.getProVices = function () {
        var roleName = "Pro-Vice";
        facultyService.getUserByRole(roleName).success(function (response) {
            if (response != null && response.Data != null) {
                $scope.proViceData = response.Data;
            }
        });
    };

    $scope.getCurrentFaculty = function () {
        var absoluteUrlPath = $window.location.href;
        var results = String(absoluteUrlPath).split('/');
        if (results != null && results.length > 0) {
            var id = results[results.length - 1];

            facultyService.getFacultyDetails(id).success(function (response) {
                $scope.currentFaculty = response.Data;
            });
        }
    };

    $scope.saveFaculty = function () {
        var editFaculty = $scope.currentFaculty;
        facultyService.saveFaculty(editFaculty).success(function (response) {
            if (response != null && response.Data != null) {
                $window.location.href = '/Faculty/Index';
            }
        });
    };

    $scope.deleteFaculty = function (deleteItem) {
        facultyService.deleteFaculty(deleteItem).success(function(response) {
            if (response != null && response.Data != null) {
                var index = $scope.faculties.indexOf(response.Data.FacultyId);
                $scope.faculties.splice(index, 1);
            }
        });
    };

    // Faculty Course Management
    $scope.currentFacultyCourse = {};
    $scope.facultyCourses = [];
    $scope.getFacultyCourses = function () {
        facultyService.getFacultyCourses().success(function (response) {
            $scope.facultyCourses = response.Data;
        });
    };

    $scope.courses = [];
    $scope.getCourses = function () {
        facultyService.getCourses().success(function (response) {
            $scope.courses = response.Data;
        });
    };

    //$scope.courses = [];
    //$scope.getCourses = function () {
    //    debugger;
    //    facultyService.getCourses().success(function (response) {
    //        $scope.courses = response.Data;
    //    });
    //};

    $scope.addFacultyCourse = function () {
        $scope.FacultyCourseId = 0;
        var facultyCourse = {
            FacultyCourseId: $scope.FacultyCourseId,
            FacultyId: $scope.selectedFaculty,
            CourseId: $scope.selectedCourse,
            Note: $scope.Note,
            Status: $scope.selectedStatus
        };

        facultyService.createFacultyCourse(facultyCourse).success(function (response) {
            if (response != null && response.Data != null) {
                $scope.currentFacultyCourse = response.Data;
                $window.location.href = '/Faculty/FacultyCourse';
            }
        });
    };

    $scope.getCurrentFacultyCourse = function () {
        var absoluteUrlPath = $window.location.href;
        var results = String(absoluteUrlPath).split('/');
        if (results != null && results.length > 0) {
            var id = results[results.length - 1];

            facultyService.getFacultyCourseDetails(id).success(function (response) {
                $scope.currentFacultyCourse = response.Data;
            });
        }
    };

    $scope.saveFacultyCourse = function () {
        var editFaculty = $scope.currentFacultyCourse;
        facultyService.saveFacultyCourse(editFaculty).success(function (response) {
            if (response != null && response.Data != null) {
                $window.location.href = '/Faculty/FacultyCourse';
            }
        });
    };

    $scope.deleteFacultyCourse = function (deleteItem) {
        facultyService.deleteFacultyCourse(deleteItem).success(function (response) {
            if (response != null && response.Data != null) {
                var index = $scope.facultyCourses.indexOf(response.Data.FacultyCourseId);
                $scope.facultyCourses.splice(index, 1);
            }
        });
    };

    // Student Management
    $scope.currentStudent = {};
    $scope.students = [];
    $scope.getStudents = function () {
        facultyService.getStudents().success(function (response) {
            $scope.students = response.Data;
        });
    };

    // get status
    $scope.stateData = [{ "StatusId": 1, "StatusName": "Inprogress" },{ "StatusId": 1, "StatusName": "Quit" }, { "StatusId": 2, "StatusName": "Save" }, { "StatusId": 2, "StatusName": "Complete" }];

    $scope.addStudent = function () {
        $scope.StudentId = 0;
        var addObject = {
            StudentId: $scope.StudentId,
            StudentCode: $scope.StudentCode,
            Email: $scope.Email,
            FullName: $scope.FullName,
            DateOfBirth: $scope.DateOfBirth,
            PhoneNumber: $scope.PhoneNumber,
            Address: $scope.Address,
            Status: $scope.selectedState
        };
        facultyService.createStudent(addObject).success(function (response) {
            if (response != null && response.Data != null) {
                $scope.currentStudent = response.Data;
                $window.location.href = '/Faculty/Student';
            }
        });
    };

    $scope.getCurrentStudent = function () {
        var absoluteUrlPath = $window.location.href;
        var results = String(absoluteUrlPath).split('/');
        if (results != null && results.length > 0) {
            var id = results[results.length - 1];
            facultyService.getStudentDetails(id).success(function (response) {
                $scope.currentStudent = response.Data;
            });
        }
    };

    $scope.saveStudent = function () {
        var editObject = $scope.currentStudent;
        facultyService.saveStudent(editObject).success(function (response) {
            if (response != null && response.Data != null) {
                $window.location.href = '/Faculty/Student';
            }
        });
    };

    $scope.deleteStudent = function (deleteObject) {
        facultyService.deleteStudent(deleteObject).success(function (response) {
            if (response != null && response.Data != null) {
                var index = $scope.students.indexOf(response.Data.StudentId);
                $scope.students.splice(index, 1);
            }
        });
    };

    // Academic Management
    $scope.currentAcademic = {};
    $scope.academics = [];
    $scope.getAcademics = function () {
        facultyService.getAcademics().success(function (response) {
            if(response != null && response.Data != null)
            {
                for (var i = 0; i < response.Data.length; i++) {
                    var academic = response.Data[i];
                    academic.FromDate = new Date(academic.FromDate);
                    academic.ToDate = new Date(academic.ToDate);
                    $scope.academics.push(academic);
                }
            }
        });
    };

    $scope.addAcademic = function () {
        $scope.AccademicSessionId = 0;
        var addObject = {
            AccademicSessionId: $scope.AccademicSessionId,
            AccSessName: $scope.AccSessName,
            FromDate: new Date($scope.FromDate),
            ToDate: new Date($scope.ToDate)
        };
        facultyService.createAcademic(addObject).success(function (response) {
            if (response != null && response.Data != null) {
                $scope.currentAcademic = response.Data;
                $window.location.href = '/Faculty/Academic';
            }
        });
    };

    $scope.getCurrentAcademic = function () {
        var absoluteUrlPath = $window.location.href;
        var results = String(absoluteUrlPath).split('/');
        if (results != null && results.length > 0) {
            var id = results[results.length - 1];
            facultyService.getAcademicDetails(id).success(function (response) {
                $scope.currentAcademic = response.Data;
                $scope.currentAcademic.FromDate = new Date($scope.currentAcademic.FromDate);
                $scope.currentAcademic.ToDate = new Date($scope.currentAcademic.ToDate);
            });
        }
    };

    $scope.saveAcademic = function () {
        var editObject = $scope.currentAcademic;
        $scope.currentAcademic.FromDate = new Date($scope.currentAcademic.FromDate);
        $scope.currentAcademic.ToDate = new Date($scope.currentAcademic.ToDate);
        facultyService.saveAcademic(editObject).success(function (response) {
            if (response != null && response.Data != null) {
                $window.location.href = '/Faculty/Academic';
            }
        });
    };

    $scope.deleteAcademic = function (deleteObject) {
        facultyService.deleteAcademic(deleteObject).success(function (response) {
            if (response != null && response.Data != null) {
                var index = $scope.academics.indexOf(response.Data.AccademicSessionId);
                $scope.academics.splice(index, 1);
            }
        });
    };

    // Student Course Management
    $scope.currentStudentCourse = {};
    $scope.studentCourses = [];
    $scope.getStudentCourses = function (courseId) {
        if (courseId != undefined) {
            $scope.getCourseStatus($scope.selectedCourse);
            facultyService.getStudentCourses(courseId).success(function(response) {
                $scope.studentCourses = response.Data;
            });
        } else {
            $scope.studentCourses = [];
        }
    };

    // get status
    $scope.stateData = [{ "StatusId": 1, "StatusName": "Inprogress" }, { "StatusId": 1, "StatusName": "Quit" }, { "StatusId": 2, "StatusName": "Save" }, { "StatusId": 2, "StatusName": "Complete" }];

    $scope.showEdit = false;
    $scope.toggleShowEdit = function() {
        $scope.showEdit = !$scope.showEdit;
    };

    $scope.gradeGroupData = [];
    $scope.getGradeGroups = function () {
        facultyService.getGradeGroups().success(function(response) {
            if (response != null && response.Data != null) {
                $scope.gradeGroupData = response.Data;
            }
        });
    };

    $scope.addStudentCourse = function () {
        $scope.StudentCourseId = 0;
        var addObject = {
            StudentCourseId: $scope.StudentCourseId,
            StudentId: $scope.selectedStudent,
            CourseId: $scope.selectedCourse,
            Status: $scope.selectedStatus
        };
        facultyService.createStudentCourse(addObject).success(function (response) {
            if (response != null && response.Data != null) {
                $scope.currentStudentCourse = response.Data;
                $window.location.href = '/Faculty/StudentCourse';
            }
        });
    };

    $scope.updateStudentCourse = function () {
        $scope.StudentCourseId = 0;
        var addObject = {
            StudentCourseId: $scope.StudentCourseId,
            StudentId: $scope.StudentId,
            CourseId: $scope.CourseId,
            Mark: $scope.Mark,
            Comment: $scope.Comment,
            GradeGroup: $scope.GradeGroup,
            Status: $scope.selectedState
        };
        facultyService.createStudentCourse(addObject).success(function (response) {
            if (response != null && response.Data != null) {
                $scope.currentStudentCourse = response.Data;
                $window.location.href = '/Faculty/StudentCourse';
            }
        });
    };

    $scope.getCurrentStudentCourse = function () {
        var absoluteUrlPath = $window.location.href;
        var results = String(absoluteUrlPath).split('/');
        if (results != null && results.length > 0) {
            var id = results[results.length - 1];
            facultyService.getStudentCourseDetails(id).success(function (response) {
                $scope.currentStudentCourse = response.Data;
            });
        }
    };

    $scope.saveStudentCourse = function (editObject) {
        facultyService.saveStudentCourse(editObject).success(function (response) {
            if (response != null && response.Data != null) {
                //$window.location.href = '/Faculty/StudentCourse';
            }
        });
    };

    $scope.approvalStatus = '';
    $scope.sendToApproval = function () {
        var editObject = { CourseId: $scope.selectedCourse, Status: 3 };
        if ($scope.approvalStatus === 'Active') {
            facultyService.saveCourse(editObject).success(function (response) {
                if (response != null && response.Data != null) {
                    if (response.Data.Status == 3) {
                        $scope.disabled = true;
                        $scope.approvalStatus = 'Pending Approval';
                    }
                    else if (response.Data.Status == 4)
                        $scope.approvalStatus = 'Approved';
                }
            });
        }
    };
    $scope.approve = function () {
        var editObject = { CourseId: $scope.selectedCourse, Status: 4 };
        if ($scope.approvalStatus === 'Pending Approval') {
            facultyService.saveCourse(editObject).success(function (response) {
                if (response != null && response.Data != null) {
                    if (response.Data.Status == 3) {
                        $scope.disabled = true;
                        $scope.approvalStatus = 'Pending Approval';
                    }
                    else if (response.Data.Status == 4)
                        $scope.approvalStatus = 'Approved';
                }
            });
        }
    };

    $scope.deleteStudentCourse = function (deleteObject) {
        facultyService.deleteStudentCourse(deleteObject).success(function (response) {
            if (response != null && response.Data != null) {
                var index = $scope.studentCourses.indexOf(response.Data.studentCourseId);
                $scope.studentCourses.splice(index, 1);
            }
        });
    };

    $scope.accademicSessions = [];
    $scope.selectedAccSession = -1;
    $scope.getAccademicSession = function () {
        facultyService.getAccademicSession().success(function (response) {
            if (response != null && response.Data != null) {
                $scope.selectedAccSession = response.Data[0].AccId;
                $scope.accademicSessions = response.Data;
                $scope.getCoursesByAccademicSession($scope.selectedAccSession);
            }
        });
    };

    $scope.coursesByAccSess = [];
    $scope.selectedCourse = -1;
    $scope.getCoursesByAccademicSession = function (id) {
        var role = $scope.roleShowCourse;
        facultyService.getCoursesByAccademicSession(id, role).success(function (response) {
            if (response != null && response.Data != null) {
                $scope.coursesByAccSess = response.Data;
                $scope.selectedCourse = $scope.coursesByAccSess[0].CourseId;
                $scope.getStudentCourses($scope.selectedCourse);
            } else {
                $scope.coursesByAccSess = [];
                $scope.studentCourses = [];
            }
        });
    };

    $scope.getCourseStatus = function (id) {
        $scope.disabled = false;
        facultyService.getCourseStatus(id).success(function (response) {
            if (response != null && response.Data != null) {
                $scope.approvalStatus = response.Data;
                if ($scope.approvalStatus === 'Pending Approval')
                    $scope.disabled = true;
            }
        });
        $scope.getUIForCurrentRole();
    };

    $scope.roleShowCourse = "guest";
    $scope.getUIForCurrentRole = function () {
        $scope.getGradeGroups();
        var absoluteUrlPath = $window.location.href;
        var results = String(absoluteUrlPath).split('/');
        if (results != null && results.length > 0) {
            var id = results[results.length - 1];

            if (id != null) {
                $scope.roleShowCourse = id;
                if ($scope.roleShowCourse === "Guest" || $scope.roleShowCourse === "Director"
                    || $scope.roleShowCourse === "guest" || $scope.roleShowCourse === "director"
                    || $scope.roleShowCourse.toLowerCase() === "pvc" || $scope.roleShowCourse.toLowerCase() === "cmanager")
                    $scope.disabled = true;
            }

        }
    };

}]);