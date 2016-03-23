cmsApp.factory('accountService', ['$http', function ($http) {
    var self = this;
    var baseAddress = 'http://localhost:58504/';
    self.createRole = function (role) {
        return $http.post(baseAddress + 'api/account/addrole', role);
    };

    self.createUser = function (user) {
        return $http.post(baseAddress + 'api/account/adduser', user);
    };

    self.getUserDetails = function(userId) {
        return $http({
            method: 'POST',
            url: baseAddress + 'api/account/getUserDetails/' + userId
        });
    };

    self.editUser = function(user) {
        return $http({
            method: 'POST',
            url: baseAddress + 'api/account/updateUser/' + user
        });
    };

    self.deleteUser = function (user) {
        return $http.post(baseAddress + 'api/account/deleteUser', user);
    };

    self.getRoles = function() {
        return $http.get(baseAddress + 'api/account/getroles');
    };

    self.getGeneralStatusList = function () {
        return $http.get(baseAddress + 'api/account/GetGeneralStatus');
    };

    self.getRoleDetails = function (roleId) {
        return $http({
            method: 'POST',
            url: baseAddress + 'api/account/GetRoleDetails/' + roleId
        });
    }

    self.getUsers = function () {
        return $http.get(baseAddress + 'api/account/getUsers');
    }

    self.saveRole = function (role) {
        return $http.post(baseAddress + 'api/account/saverole', role);
    }

    self.deleteRole = function(role) {
        //return $http({
        //    method: 'POST',
        //    url: baseAddress + 'api/account/deleteRole' + role
        //});
        return $http.post(baseAddress + 'api/account/deleteRole', role);
    };

    self.createUserRole = function(userRole) {
        return $http.post(baseAddress + 'api/account/AddUserRole', userRole);
    };

    self.getUserRoles = function () {
        return $http.get(baseAddress + 'api/account/GetUserRoles');
    };

    self.getUserRoleDetails = function (userRoleId) {
        return $http({
            method: 'POST',
            url: baseAddress + 'api/account/GetUserRoleDetails/' + userRoleId
        });
    };
    return self;
}]);