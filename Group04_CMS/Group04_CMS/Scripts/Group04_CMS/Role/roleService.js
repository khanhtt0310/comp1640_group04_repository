cmsApp.factory('roleService', ['$http', function ($http) {
    var self = this;
    var baseAddress = 'http://localhost:58504/';
    self.createRole = function (role) {
        return $http.post(baseAddress + 'api/account/addrole', role);
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

    return self;
}]);