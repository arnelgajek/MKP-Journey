app.controller('JourneyReportController', function ($scope, $location, $http, $route, $location) {
    $scope.titleJourneyReport = "Rapport";

    var vehicleUrl = "http://localhost:53201/api/vehicle";
    var generatePdfApi = "http://localhost:53201/api/reports/generate";
    var chartApi = "http://localhost:53201/api/chart";

    // Hides the chart in the begging when no data is asked for:
    $scope.showTheChart = false;

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

    var fromPickedDate = new String();
    var toPickedDate = new String();

    $scope.report = {
        VehicleId: '',
        fromDate: fromPickedDate,
        toDate: toPickedDate
    };

    //The button that posts data into chartApi:
    $scope.getTheChart = function () {
        $http({
            method: 'POST',
            url: chartApi,
            data: $.param($scope.report),  // Passes in the data as a string.
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded',
                'Authorization': 'Bearer ' + localStorage.getItem('bearer')
            }
        }).then(function (response) {
            $scope.showTheChart = true;
            var trips = response.data;
            $scope.chartLabels = ["Resor mellan 0-20km", "Resor mellan 21-50km", "Resor mellan 51-200km"];
            $scope.chartData = [0, 0, 0];

            angular.forEach(response.data, function (trip) {
                var kmTotalChart = trip.KmStop - trip.KmStart;
                if (kmTotalChart <= 20) {
                    $scope.chartData[0]++;
                } else if (kmTotalChart > 20 && kmTotalChart <= 50) {
                    $scope.chartData[1]++;
                } else if (kmTotalChart > 50) {
                    $scope.chartData[2]++;
                };
                $scope.chartClick = function (event) {
                    if (event) {
                        var index = event[0]._index;
                        console.log(trips[index]);
                    }
                };
            });
        });

        // The button that generates the PDF:
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
    };
});