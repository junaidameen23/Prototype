(function () {
    'use strict';
    angular.module('lmtApp').controller('employeeController',
    function ($state, $window, toastr, genericService) {
        var EC = this;

        EC.GetAllEmployees = function () {
            genericService.Get("GetAllEmployees")
                .then(function (data) {
                    if (!genericService.IsNullOrEmptyOrUndefined(data) && data.length > 0) {
                        EC.employees = data;
                    }
                })
        }

        EC.GetAllEmployees();

    });
})();