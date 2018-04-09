app.controller('CreateAccountController', function ($scope, $http, $route) {
    $scope.titleCreateAccount = "Skapa konto";
     $scope.createAccountData = {};

    var accountUrl = "http://localhost:53201/api/account/register";

    // Create new account:
    $scope.createAccount = function () {
        $http({
            method: 'POST',
            url: accountUrl,
            data: $.param($scope.createAccountData),  // Passes in the data as a string.
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' }  // Set the headers so Angular passing info as form data (not request payload)
        }).then(function (error) {
            console.log(error);
        });
    };
});
