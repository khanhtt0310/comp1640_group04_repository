'use strict';

// Declare app level module which depends on filters, and services
var misApp = angular.module('misApp', [
  'ngRoute',
  'misApp.filters',
  'misApp.directives',
  'ngAnimate'
]).

config(['$routeProvider', function ($routeProvider) {
    $routeProvider
        .when('/home',
            {
                templateUrl: '/home/home',
                controller: 'homeController'
            })
            .when('/school',
            {
                templateUrl: '/school',
                controller: 'schoolController'
            })
            .when('/school/edit/:id',
            {
                templateUrl: '/school/edit',
                controller: 'schoolEditController'
            })
            .when('/help',
            {
                templateUrl: '/help'
            })
            .otherwise(
            {
                redirectTo: '/home'
            });
}]);
