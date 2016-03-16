angular.module('accountApp').factory('accountService', ['$http', function ($http) {
    var self = this;
    self.createRole = function (role) {
        return $http.post('../api/account/addrole', role);
    };

    self.createUser = function (user) {
        return $http.post('../api/account/adduser', user);
    };

    self.getRoles = function() {
        return $http.get('../api/account/getroles');
    };

    self.getGeneralStatusList = function () {
        return $http.get('../api/account/GetGeneralStatus');
    };

    self.getRoleDetails = function(roleId) {
        return $http.post('../api/account/getRoleDetails', roleId);
    }

    self.getUsers = function () {
        return $http.get('../api/account/getUsers');
    }
    return self;
}]);