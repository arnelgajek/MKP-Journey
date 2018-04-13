app.controller('CreateAccountController', function ($scope, $http, $route, $location) {
    $scope.titleCreateAccount = "Skapa konto";
    //$scope.createAccountData = {};

    var accountUrl = "http://localhost:53201/api/Account/Register";

    // Create new account:
    $scope.createAccount = function () {
        $http({
            method: 'POST',
            url: accountUrl,
            data: $.param($scope.createAccountData),  // Passes in the data as a string.
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' }  // Set the headers so Angular passing info as form data (not request payload)
        }).then(function (data) { // Sends the user to the Login-page after successfully creating an account.
            $location.url('/');
        }, function (error) {
            console.log(error);
        });
    };
});