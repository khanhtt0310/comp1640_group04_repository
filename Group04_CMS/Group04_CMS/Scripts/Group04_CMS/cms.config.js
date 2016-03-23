angular.module('cmsApp').config(function ($routeProvider) {
    $routeProvider

        // route for the home page
        .when('/', {
            templateUrl: 'Home/Index.cshtml',
            controller: 'mainController'
        })

        .when('/account/role', {
            templateUrl: 'Account/Role.cshtml',
            controller: 'roleController'
        })

        .when('/account/editrole', {
            templateUrl: 'Account/EditRole.cshtml',
            controller: 'roleController'
        })

        .when('/account/createrole', {
            templateUrl: 'Account/CreateRole.cshtml',
            controller: 'roleController'
        });
});