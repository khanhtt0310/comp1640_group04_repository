cmsApp.controller('facultyController', ['$scope', 'facultyService', '$window', function ($scope, facultyService, $window) {
    $scope.currentFaculty = {};
    $scope.faculties = [];
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
            Note: $scope.Note
        };
        facultyService.createFaculty(faculty,
            function (response) {
                if (response != null && response.Data != null) {
                    $scope.currentFaculty = response.Data;
                    $window.location.href = '/Faculty/Index';
                }
                

            },
            function (error) {
                // error
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
    $scope.getCourses = function() {
        facultyService.getCourses().success(function (response) {
            $scope.courses = response.Data;
        });
    };

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

    // Student Course Management
    $scope.currentStudentCourse = {};
    $scope.studentCourses = [];
    $scope.getStudentCourses = function () {
        facultyService.getStudentCourses().success(function (response) {
            $scope.currentStudentCourse = response.Data;
        });
    };

    // get status
    $scope.stateData = [{ "StatusId": 1, "StatusName": "Inprogress" }, { "StatusId": 1, "StatusName": "Quit" }, { "StatusId": 2, "StatusName": "Save" }, { "StatusId": 2, "StatusName": "Complete" }];

    $scope.addStudentCourse = function () {
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

    $scope.saveStudentCourse = function () {
        var editObject = $scope.currentStudentCourse;
        facultyService.saveStudentCourse(editObject).success(function (response) {
            if (response != null && response.Data != null) {
                $window.location.href = '/Faculty/StudentCourse';
            }
        });
    };

    $scope.deleteStudentCourse = function (deleteObject) {
        facultyService.deleteStudentCourse(deleteObject).success(function (response) {
            if (response != null && response.Data != null) {
                var index = $scope.studentCourses.indexOf(response.Data.studentCourseId);
                $scope.studentCourses.splice(index, 1);
            }
        });
    };

}]);