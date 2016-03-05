'use strict';

/* Services */

misApp
    .factory('schoolService', function ($resource) {
        var odataUrl = '/odata/school';
        return $resource('', {},
            {
                'getAll': { method: 'GET', url: odataUrl },
                'getTop10': { method: 'GET', url: odataUrl + '?$top=10' },
                'create': { method: 'POST', url: odataUrl },
                'patch': { method: 'PATCH', params: { key: '@key' }, url: odataUrl + '(:key)' },
                'getSchool': { method: 'GET', params: { key: '@key' }, url: odataUrl + '(:key)' },
                'deleteSchool': { method: 'DELETE', params: { key: '@key' }, url: odataUrl + '(:key)' },
                'addSchool': { method: 'POST', url: odataUrl }
            });
    }).factory('notificationFactory', function () {
        return {
            success: function (text) {
                toastr.success(text, "Success");
            },
            error: function (text) {
                toastr.error(text, "Error");
            }
        };
    })