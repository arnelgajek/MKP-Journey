app.controller('JourneyReportController', function ($scope, $location, $http, $route, $location) {
    $scope.titleJourneyReport = "Rapport";

    var vehicleUrl = "http://localhost:53201/api/vehicle";
    var generatePdfApi = "http://localhost:53201/api/reports/generate";
    //var chartApi = "http://localhost:53201/api/chart";

    if (localStorage.getItem("bearer") === null) {
        $location.path('/');
    }

    // Retrieves vehicles from the database:
    $http.get(vehicleUrl, {
        headers: { 'Authorization': 'Bearer ' + localStorage.getItem('bearer') } // Gives you the authorization to get all the vehicles from db.
    }).then(function (response) {
        $scope.vehicles = response.data;
    }, function (error) {
        console.log(error);
        });

    $scope.createPDF = function () {
        $http({
            method: 'POST',
            url: generatePdfApi,
            data: $.param($scope.report),  // Passes in the data as a string.
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded',
                'Authorization': 'Bearer ' + localStorage.getItem('bearer')
            }
        }).then(function (response) {
            $scope.pdfUrl = response.data;
            $scope.createPDF = true;
        }, function (error) {
            $scope.pdfUrl = "";
            console.log(error);
        });
    }
});