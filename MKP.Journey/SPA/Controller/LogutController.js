app.controller('LogoutController', function ($scope, $http, $route, $location, $window) {

    // Destroys the bearer-token:
    $scope.LogOut = function (LogOutData) {
        localStorage.removeItem("bearer");
        $location.path('/');
    };

});