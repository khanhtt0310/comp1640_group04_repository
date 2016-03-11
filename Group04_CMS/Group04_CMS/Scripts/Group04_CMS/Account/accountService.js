angular.module('accountApp').factory('accountService', ['$http', function ($http) {
    var self = this;
    self.createRole = function (role, status, fnSuccess, fnError) {
        return $http({
            method: 'POST',
            url: '../api/Account/AddRole' + role
        }).success(fnSuccess).error(fnError);
    };

    self.getGeneralStatusList = function () {
        return $http.get('../api/account/GetGeneralStatus');
    };
    return self;
}]);