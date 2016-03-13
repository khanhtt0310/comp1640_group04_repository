angular.module('accountApp').controller('accountController', ["$scope", "accountService",
    function ($scope, accountService) {
        // get all role function
        $scope.roles = [];
        $scope.getRoles = function () {
            accountService.getRoles().success(function (response) {
                $scope.roles = response.Data;
            });
        };

        // add new role
        $scope.newRole = {};
        $scope.addRole = function () {
            $scope.RoleId = 0;
            debugger;
            alert($scope.selectedStatus);
            var role = {
                    RoleId: $scope.RoleId,
                    RoleName: $scope.RoleName,
                    Note: $scope.Note
            };
            if ($scope.selectedStatus === "1")
                role.Status = 'Active';
            else {
                role.Status = 'Inactive';
            }
            accountService.createRole(role,
                function (data) {
                    debugger;
                    $scope.newRole = data;
                },
                function(error) {
                    // error
                });
        };

        // get role status
        $scope.statusData = [];
        accountService.getGeneralStatusList().success(function (response) {
            $scope.statusData = response.Data;
        });

    }]);