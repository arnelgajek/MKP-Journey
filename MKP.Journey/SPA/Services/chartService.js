(function () {
    angular.module('app').factory('chartService', ['$q', '$http', function ($q, $http) {

        var api = {
            get: get,
            post: post
        };

        return api;

        function get(method) {
            var deferred = $q.defer();
            $http.get('/api/charts/' + method).then(function (data, status, headers, config) {
                deferred.resolve({
                    success: true,
                    data: data.data
                });
            }, function (response) {
                deferred.reject({
                    data: response,
                    success: false
                });
            });
            return deferred.promise;
        }
        function post(method, postData) {
            var deferred = $q.defer();
            $http.post('/api/charts' + method, postData).then(function (data, status, headers, vconfig) {
                deferred.resolve({
                    success: true,
                    data: data.data
                });
            }, function (response) {
                deferred.reject({
                    data: response,
                    success: false
                });
            });
            return deferred.promise;
        }
    }]);
}());