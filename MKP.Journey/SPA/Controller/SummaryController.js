app.controller('SummaryController', function ($scope, $http, $route, $location) {
    //$scope.titleWelcome = "Welcome";
    $scope.titleOnGoingJourney = "Pågående resa:";

    //var logOutUrl = "http://localhost:53201/api/Account/LogOut";

    if (localStorage.getItem("bearer") === null) {
        $location.path('/');
    }

    //$scope.signOutAccount = function () {
    //    $http({
    //        method: 'POST',
    //        url: logOutUrl,
    //        data: $.param($scope.createAccountData),  // Passes in the data as a string.
    //        headers: { 'Content-Type': 'application/x-www-form-urlencoded' }  // Set the headers so Angular passing info as form data (not request payload)
    //    }).then(function (error) {
    //        console.log(error);
    //    });
    //};
});