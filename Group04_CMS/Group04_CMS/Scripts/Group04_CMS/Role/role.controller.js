cmsApp.controller('roleController', ['$scope', 'roleService', '$window',
    function ($scope, roleService, $window) {
        // get all role function
        $scope.roles = [];
        $scope.getRoles = function () {
            roleService.getRoles().success(function (response) {
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
            roleService.createRole(role,
                function (data) {
                    $scope.newRole = data;
                },
                function(error) {
                    // error
                });
        };

        // get role status
        $scope.statusData = [];
        roleService.getGeneralStatusList().success(function (response) {
            $scope.statusData = response.Data;
        });
        
        // Get current Role
        $scope.currentRole = {};
        $scope.getCurrentRole = function () {
            var absoluteUrlPath = $window.location.href;
            var results = String(absoluteUrlPath).split("/");
            if (results != null && results.length > 0) {
                var roleId = results[results.length - 1];
                roleService.getRoleDetails(roleId).success(function (response) {
                    $scope.currentRole = response.Data;
                });
            }
        };

        // save role
        $scope.editRole = function () {
            var role = $scope.currentRole;
            roleService.saveRole(role, function (data) {

            });
        };

        // delete role
        $scope.removeRole = function (role) {
            roleService.deleteRole(role).success(function (response) {
                if (response != null && response.Data != null) {
                    var index = $scope.roles.indexOf(response.Data.RoleId);
                    $scope.roles.splice(index, 1);
                }
            });
        };
    }]);