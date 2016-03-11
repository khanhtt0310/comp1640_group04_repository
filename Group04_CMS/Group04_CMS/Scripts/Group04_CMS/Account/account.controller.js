angular.module('accountApp').controller('accountController', ["$scope", "accountService",
    function ($scope, accountService) {
        $scope.newRole = {};
        $scope.addRole = function() {
            $scope.RoleId = 0;
            var role = {
                    RoleId: $scope.RoleId,
                    RoleName: $scope.RoleName,
                    Status: $scope.Status,
                    Note: $scope.Note
            };
            accountService.createRole(role,
                function(data) {
                    $scope.newRole = data;
                },
                function(error) {
                    // error
                });
        };

        $scope.statusData = null;
        accountService.getGeneralStatusList().then(function(response) {
            $scope.statusData = response.Data;
        });

    }]);