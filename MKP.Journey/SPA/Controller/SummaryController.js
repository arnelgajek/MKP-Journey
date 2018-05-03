app.controller('SummaryController', function ($scope, $http, $route, $location) {
    $scope.titleOnGoingJourney = "Pågående resa:";

    if (localStorage.getItem("bearer") === null) {
        $location.path('/');
    }
});