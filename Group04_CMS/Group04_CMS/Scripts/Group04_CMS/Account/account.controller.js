cmsApp.controller('accountController', ['$scope', 'accountService', '$window',
    function ($scope, accountService, $window) {
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

        $scope.saveUser = function() {
            accountService.saveUser($scope.currentUser, function (response) {
                
            });
        };
        // get user details
        $scope.currentUser = {};
        $scope.getCurrentUser = function() {
            var absoluteUrlPath = $window.location.href;
            var results = String(absoluteUrlPath).split('/');
            if (results != null && results.length > 0) {
                var userId = results[results.length - 1];
                accountService.getUserDetails(userId).success(function(response) {
                    $scope.currentUser = response.Data;
                });
            }
        };
        // delete user
        $scope.removeUser = function (user) {
            accountService.deleteUser(user).success(function (response) {
                if (response != null && response.Data != null) {
                    var index = $scope.roles.indexOf(response.Data.UserId);
                    $scope.users.splice(index, 1);
                }
            });
        };
        
        // Get current Role
        $scope.currentRole = {};
        $scope.getCurrentRole = function () {
            var absoluteUrlPath = $window.location.href;
            var results = String(absoluteUrlPath).split("/");
            if (results != null && results.length > 0) {
                var roleId = results[results.length - 1];
                accountService.getRoleDetails(roleId).success(function(response) {
                    $scope.currentRole = response.Data;
                });
            }
        };

        // save role
        $scope.editRole = function () {
            var role = $scope.currentRole;
            accountService.saveRole(role, function (data) {

            });
        };

        // delete role
        $scope.removeRole = function (role) {
            accountService.deleteRole(role).success(function(response) {
                if (response != null && response.Data != null) {
                    var index = $scope.roles.indexOf(response.Data.RoleId);
                    $scope.roles.splice(index, 1);
                }
            });
        };

        // add user role
        $scope.userRole = {};
        $scope.addUserRole = function () {
            var userRoleModel = {
                UserId: $scope.selectedUser,
                RoleId: $scope.selectedRole,
                Note: $scope.Note
            };
            if ($scope.selectedStatus === "1")
                userRoleModel.Status = 'Active';
            else {
                userRoleModel.Status = 'Inactive';
            }
            accountService.createUserRole(userRoleModel).success(function (response) {
                $scope.userRole = response.Data;
            });
        };

        // get user roles
        $scope.userRoles = [];
        $scope.getUserRoles = function () {
            accountService.getUserRoles().success(function (response) {
                $scope.userRoles = response.Data;
            });
        };

        // Get user role details
        $scope.getUserRoleDetails = function () {
            var absoluteUrlPath = $window.location.href;
            var results = String(absoluteUrlPath).split("/");
            if (results != null && results.length > 0) {
                var userRoleId = results[results.length - 1];
                accountService.getUserRoleDetails(userRoleId).success(function (response) {
                    $scope.userRole = response.Data;
                });
            }
            
        };
    }]);