angular.module('accountApp').controller('accountController', ['$scope', 'accountService',
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

        // Get Role Detail
        //$scope.role = {};
        //$scope.getRoleDetails = function () {
        //    accountService.getRoleDetails($stateParamsProvider.id).success(function (response) {
        //        $scope.role = response.Data;
        //    });
        //};

        // Get Users
        $scope.users = [];
        $scope.getUsers = function () {
            accountService.getUsers().success(function (response) {
                $scope.users = response.Data;
            });
        };
        // Add user
        $scope.user = {};
        $scope.addUser = function () {
            alert("Add user");
            $scope.UserId = 0;
            var newUser = {
                UserId: $scope.RoleId,
                UserName: $scope.UserName,
                Email: $scope.Email
            };
            if ($scope.selectedStatus === "1")
                newUser.Status = 'Active';
            else {
                newUser.Status = 'Inactive';
            }
            accountService.createUser(newUser,
                function (data) {
                    $scope.user = data;
                },
                function (error) {
                    // error
                });
        };
    }]);