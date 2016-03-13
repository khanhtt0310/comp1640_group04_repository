angular.module('accountApp').factory('accountService', ['$http', function ($http) {
    var self = this;
    self.createRole = function (role) {
        return $http.post('../api/account/addrole', role);
    };
    self.getRoles = function() {
        return $http.get('../api/account/getroles');
    };

    self.getGeneralStatusList = function () {
        return $http.get('../api/account/GetGeneralStatus');
    };
    return self;
}]);