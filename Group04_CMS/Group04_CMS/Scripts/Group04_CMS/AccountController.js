var app = angular.module('cmsApp', []);
app.controller('AccountCtroller', ['$scope','accountService', function ($scope, accountService) {
    $scope.statusData = null;
    accountService.GetGeneralStatus().then(function (data) {
        $scope.statusData = data;
    }, function() {alert('Error occured !!!')}
    );
}]);

app.factory('accountService', function ($http) {
    var fac = {};
    fac.GetGeneralStatus = function () {
        return $http.get('../api/account/GetGeneralStatus');
    }
    return fac;
});