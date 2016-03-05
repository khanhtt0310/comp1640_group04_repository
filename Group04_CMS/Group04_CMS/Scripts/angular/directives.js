'use strict';

/* Directives */


angular.module('misApp.directives', []).
  directive('appVersion', ['version', function (version) {
      return function (scope, elm, attrs) {
          elm.text(version);
      };
  }]);
