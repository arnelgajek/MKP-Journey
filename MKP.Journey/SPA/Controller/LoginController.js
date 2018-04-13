app.controller('LoginController', function ($scope, $http, $route, $location, $window) {
    $scope.titleLogin = "Journey";

    var loginData = this;
    loginData.token = "";

    // Login to your account:
    $scope.loginForm = function (loginData) {
        var data = "grant_type=password&username=" + loginData.username + "&password=" + loginData.password;
        $http.post('/token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).then(function (response) {

        loginData.token = response.data.access_token;

        }).then(function (data) {
            $location.url('/Summary');
        }, function (error) {
            console.log(error);
        });
    };
});

// Glömt lösenord:
// Ej obligatoriskt, gör detta om det finns tid över.
