app.controller('LoginController', function ($scope, $http, $route) {
    $scope.titleLogin = "Journey";

    //var loginUrl = "http://localhost:53201/api/Account";
    //var data = "grant_type=password&username" + $scope.username + "&password=" + $scope.password;
    //$scope.token = "";

    //// Create new account:
    //$scope.loginForm = function () {
    //    $http({
    //        method: 'POST',
    //        url: accountUrl + '/Token', data,
    //        headers: { 'Content-Type': 'application/x-www-form-urlencoded' }  // Set the headers so Angular passing info as form data (not request payload)
    //    }).then(function (response) {
    //        $scope.token = response.data.access_token;
    //    }, function (error, status) {
    //        console.log(error);
    //    });
    //};
});

// Logga in:
// Sida 65 i PPT 03

// Glömt lösenord:
// Ej obligatoriskt, gör detta om det finns tid över.
