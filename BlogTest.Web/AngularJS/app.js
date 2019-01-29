serviceBase = 'http://localhost:60549/api/';

var lmtApp = angular.module('lmtApp', ['ui.router', 'oc.lazyLoad', 'toastr']);


lmtApp.config(function ($stateProvider, $urlRouterProvider, $locationProvider) {
    $stateProvider
        .state('employee', {
            url: '/employee',
            controller: "employeeController",
            controllerAs: "EC",
            templateUrl: "/AngularJS/Views/employee.html",
            resolve: {
                lazyLoad: function ($ocLazyLoad) {
                    return $ocLazyLoad.load([
                        { type: 'js', path: '/AngularJS/Controllers/employeeController.js' }
                    ]);
                }
            }
        })
        .state('addEmployee', {
            url: '/addEmployee/:employeeId',
            controller: "addEmployeeController",
            controllerAs: "AEC",
            templateUrl: "/AngularJS/Views/addEmployee.html",
            resolve: {
                lazyLoad: function ($ocLazyLoad) {
                    return $ocLazyLoad.load([
                        { type: 'js', path: '/AngularJS/Controllers/addEmployeeController.js' }
                    ]);
                }
            }
        });

    $urlRouterProvider.otherwise('/employee');
    $locationProvider.html5Mode(true);
});

lmtApp.config(['$httpProvider', function ($httpProvider) {
    $httpProvider.interceptors.push(function ($q, $rootScope, $window, $location) {
        var numLoadings = 0;
        return {
            request: function (config) {
                numLoadings++;
                // Show loader
                $rootScope.$broadcast("loader_show");
                return config;
            },
            requestError: function (rejection) {
                if (!(--numLoadings)) {
                    // Hide loader
                    $rootScope.$broadcast("loader_hide");
                }
                return $q.reject(rejection);
            },
            response: function (response) {
                if ((--numLoadings) === 0) {
                    // Hide loader
                    $rootScope.$broadcast("loader_hide");
                }

                if (response.status == "401") {
                    $location.path('/login');
                }
                //the same response/modified/or a new one need to be returned.
                return response;
            },
            responseError: function (rejection) {
                if (!(--numLoadings)) {
                    // Hide loader
                    $rootScope.$broadcast("loader_hide");
                }

                if (rejection.status == "401") {
                    $location.path('/login');
                }
                return $q.reject(rejection);
            }
        };
    });
}]);