var cmsApp = angular.module('cmsApp', ['ui.bootstrap']);
var baseAddress = '/';
cmsApp.directive('ngReallyClick', ['$uibModal',
    function ($uibModal) {

        var ModalInstanceCtrl = function ($scope, $uibModalInstance) {
            $scope.ok = function () {
                $uibModalInstance.close();
            };

            $scope.cancel = function () {
                $uibModalInstance.dismiss('cancel');
            };
        };

        return {
            restrict: 'A',
            scope: {
                ngReallyClick: "&"
            },
            link: function (scope, element, attrs) {
                element.bind('click', function () {
                    var message = attrs.ngReallyMessage || "Are you sure ?";

                    var modalHtml = '<div class="modal-body">' + message + '</div>';
                    modalHtml += '<div class="modal-footer"><button class="btn btn-primary" ng-click="ok()">OK</button><button class="btn btn-warning" ng-click="cancel()">Cancel</button></div>';

                    var modalInstance = $uibModal.open({
                        template: modalHtml,
                        controller: ModalInstanceCtrl
                    });

                    modalInstance.result.then(function () {
                        scope.ngReallyClick();
                    }, function () {
                        //Modal dismissed
                    });

                });

            }
        }
    }
]);

cmsApp.directive('customDatepicker', function($compile, $timeout) {
    return {
        replace: true,
        //templateUrl: 'custom-datepicker.html',
        scope: {
            ngModel: '=',
            dateOptions: '@',
            dateDisabled: '@',
            opened: '=',
            min: '@',
            max: '@',
            popup: '@',
            options: '@',
            name: '@',
            id: '@'
        },
        link: function($scope, $element, $attrs, $controller) {

        }
    };
});

cmsApp.directive('ngDisabled', function () {
    return {
        controller: function ($scope, $attrs) {
            var self = this;
            $scope.$watch($attrs.ngDisabled, function (isDisabled) {
                self.isDisabled = isDisabled;
            });
        }
    };
});

function reactToParentNgDisabled(tagName) {
    cmsApp.directive(tagName, function () {
        return {
            restrict: 'E',
            require: '?^ngDisabled',
            link: function (scope, element, attrs, ngDisabledController) {
                if (!ngDisabledController) return;
                scope.$watch(function () {
                    return ngDisabledController.isDisabled;
                }, function (isDisabled) {
                    element.prop('disabled', isDisabled);
                });
            }
        };
    });
}

['input', 'select', 'button', 'textarea'].forEach(reactToParentNgDisabled);
