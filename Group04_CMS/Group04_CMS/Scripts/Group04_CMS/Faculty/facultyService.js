cmsApp.factory('facultyService', ['$http', function($http) {
    var self = this;
    
    self.getFaculties = function() {
        return $http({
            method: 'GET',
            url: baseAddress + 'api/faculty/getFaculties'
        });
    };

    self.createFaculty = function(faculty) {
        return $http({
            method: 'POST',
            url: baseAddress + 'api/faculty/addFaculty',
            data: faculty
        });
    };

    self.getFacultyDetails = function (facultyId) {
        return $http.post(baseAddress + 'api/faculty/GetFacultyDetails/' + facultyId);
    };

    self.saveFaculty = function(faculty) {
        return $http({
            method: 'POST',
            url: baseAddress + 'api/faculty/saveFaculty',
            data: faculty
        });
    };

    self.deleteFaculty = function (deleteItem) {
        return $http({
            method: 'POST',
            url: baseAddress + 'api/faculty/DeleteFaculty',
            data: deleteItem
        });
    };

    // Faculty Course Management
    self.getFacultyCourses = function() {
        return $http({
            method: 'Get',
            url: baseAddress + 'api/faculty/GetFacultyCourses'
        });
    };

    self.getCourses = function() {
        return $http({
            method: 'GET',
            url: baseAddress + 'api/faculty/GetCourses'
        });
    };

    self.createFacultyCourse = function (newItem) {
        return $http({
            method: 'POST',
            url: baseAddress + 'api/faculty/addFacultyCourse',
            data: newItem
        });
    };

    self.getFacultyCourseDetails = function (id) {
        return $http.post(baseAddress + 'api/faculty/GetFacultyCourseDetails/' + id);
    };

    self.saveFacultyCourse = function (editItem) {
        return $http({
            method: 'POST',
            url: baseAddress + 'api/faculty/SaveFacultyCourse',
            data: editItem
        });
    };

    self.deleteFacultyCourse = function (deleteItem) {
        return $http({
            method: 'POST',
            url: baseAddress + 'api/faculty/DeleteFacultyCourse',
            data: deleteItem
        });
    };

    // Student Mangement
    self.getStudents = function () {
        return $http({
            method: 'GET',
            url: baseAddress + 'api/faculty/getStudents'
        });
    };

    self.createStudent = function (addObject) {
        return $http({
            method: 'POST',
            url: baseAddress + 'api/faculty/addStudent',
            data: addObject
        });
    };

    self.getStudentDetails = function (id) {
        return $http.post(baseAddress + 'api/faculty/GetStudentDetails/' + id);
    };

    self.saveStudent = function (editObject) {
        return $http({
            method: 'POST',
            url: baseAddress + 'api/faculty/saveStudent',
            data: editObject
        });
    };

    self.deleteStudent = function (deleteObject) {
        return $http({
            method: 'POST',
            url: baseAddress + 'api/faculty/DeleteStudent',
            data: deleteObject
        });
    };

    // Student Course Mangement
    self.getStudentCourses = function (id) {
        return $http({
            method: 'POST',
            url: baseAddress + 'api/faculty/getStudentCourses/' + id
        });
    };

    self.getGradeGroups = function() {
        return $http({
            method: 'GET',
            url: baseAddress + 'api/faculty/getGradeGroups'
        });
    };

    self.createStudentCourse = function (addObject) {
        return $http({
            method: 'POST',
            url: baseAddress + 'api/faculty/addStudentCourse',
            data: addObject
        });
    };

    self.getStudentCourseDetails = function (id) {
        return $http.post(baseAddress + 'api/faculty/GetStudentCourseDetails/' + id);
    };

    self.saveStudentCourse = function (editObject) {
        return $http({
            method: 'POST',
            url: baseAddress + 'api/faculty/saveStudentCourse',
            data: editObject
        });
    };

    self.deleteStudentCourse = function (deleteObject) {
        return $http({
            method: 'POST',
            url: baseAddress + 'api/faculty/DeleteStudentCourse',
            data: deleteObject
        });
    };

    return self;
}]);