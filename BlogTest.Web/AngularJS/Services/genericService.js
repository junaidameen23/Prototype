(function () {
    'use strict';
    lmtApp.service('genericService',
        function ($http, $q, $location) {


            //// Set header only once for first request.
            //if (authenticationService.initializationDone() != undefined && authenticationService.initializationDone() == false) {
            //    authenticationService.setHeader($http);
            //}

            //Generic Get function.
            this.Get = function (apiUrl, data) {
                debugger;
                var url = serviceBase + apiUrl;
                var deferred = $q.defer();
                $http.get(url, { params: data }).then(function (data) {
                    deferred.resolve(data.data);
                }, function (error) {
                    deferred.reject(error);
                });
                return deferred.promise;
            }

            //Generic Post function.
            this.Post = function (apiUrl, data) {

                var url = serviceBase + apiUrl;
                var deferred = $q.defer();
                $http.post(url, data).then(function (data) {
                    deferred.resolve(data.data);
                }, function (error) {
                    deferred.reject(error);
                });
                return deferred.promise;
            }

            //Generic Put function.
            this.Put = function (apiUrl, data) {
                var url = serviceBase + apiUrl;
                var deferred = $q.defer();
                $http.put(url, data).then(function (data) {
                    deferred.resolve(data.data);
                }, function (error) {
                    deferred.reject(error);
                });
                return deferred.promise;
            }

            //Generic Delete function.
            this.Delete = function (apiUrl, data) {
                var url = serviceBase + apiUrl;
                var deferred = $q.defer();
                $http.delete(url, { params: data }).then(function (data) {
                    deferred.resolve(data.data);
                }, function (error) {
                    deferred.reject(error);
                });
                return deferred.promise;
            }

            // To check Null or Empty or Undefined.
            this.IsNullOrEmptyOrUndefined = function (value) {
                return !value;
            }

        }
    );
})();