(function () {
    'use strict';
    angular.module('lmtApp').controller('addEmployeeController',
    function ($state, $stateParams, $window, toastr, genericService) {
        var AEC = this;

        AEC.GetAllGenders = function () {
            genericService.Get("GetAllGenders")
                .then(function (data) {
                    debugger;
                    if (!genericService.IsNullOrEmptyOrUndefined(data) && data.length > 0) {
                        AEC.Genders = data;
                    }
                })
        }
        AEC.GetAllGenders();

        AEC.GetEmployeeById = function (employeeId) {
            debugger;
            genericService.Get("GetEmployeeById", {
                employeeId: employeeId,
            })
                .then(function (data) {
                    if (!genericService.IsNullOrEmptyOrUndefined(data)) {
                        AEC.employee = data;
                    }
                })
        }

        if (!genericService.IsNullOrEmptyOrUndefined($stateParams.employeeId)) {
            AEC.GetEmployeeById($stateParams.employeeId);
        }


        AEC.submitLogin = function () {
            genericService.Post("SubmitEmployee", AEC.employee)
                .then(function (data) {
                    if (data) {
                        $state.go('employee');
                    }
                }, function () {
                    console.log("Failure");
                });
        }

    });
})();