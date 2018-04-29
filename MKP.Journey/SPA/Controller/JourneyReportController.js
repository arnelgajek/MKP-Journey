app.controller('JourneyReportController', function ($scope, $location) {
    $scope.titleJourneyReport = "Rapport";

    if (localStorage.getItem("bearer") === null) {
        $location.path('/');
    }
});