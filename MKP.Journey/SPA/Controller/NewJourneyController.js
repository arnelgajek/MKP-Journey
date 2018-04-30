app.controller('NewJourneyController', function ($scope, $http, $route, $location, $filter) {
    $scope.titleNewJourney = "Registrera ny resa";
    $scope.formData = {};
    $scope.trip = {
        startAddress: '',
        stopDestination: ''
    };

    var tripUrl = "http://localhost:53201/api/trips";
    var vehicleUrl = "http://localhost:53201/api/vehicle";

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

    // START GEOLOCATION:
    $scope.getStartLocation = function () {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(function (position) {

                var geocoder = new google.maps.Geocoder();
                var latLng = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);

                geocoder.geocode({ 'location': latLng }, function (results, status) {
                    if (status === 'OK') {
                        if (results[0]) {
                            $scope.trip.startAddress = results[0].formatted_address;
                            $scope.$apply();
                            console.log($scope.trip.startAddress);
                        } else {
                            console.log("No results found.");
                        }
                    } else {
                        console.log("Geocoder failed due to: " + status);
                    }
                });

            });
        } else {
            alert("Geolocation is not supported by this browser.");
        }
    };

    // STOP GEOLOCATION:
    $scope.getStopLocation = function () {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(function (position) {

                var geocoder = new google.maps.Geocoder();
                var latLng = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);

                geocoder.geocode({ 'location': latLng }, function (results, status) {
                    if (status === 'OK') {
                        if (results[0]) {
                            $scope.trip.stopDestination = results[0].formatted_address;
                            $scope.$apply();
                            console.log($scope.trip.stopDestination);
                        } else {
                            console.log("No results found.");
                        }
                    } else {
                        console.log("Geocoder failed due to: " + status);
                    }
                });

            });
        } else {
            alert("Geolocation is not supported by this browser.");
        }
    };

     //Post new trip with values that has been entered to the database:
    $scope.newTrip = function (trip) {
        trip.date = $filter('date')(trip.date, 'yyyy-MM-dd');

        $http({
            method: 'POST',
            url: tripUrl,
            data: $.param($scope.trip),  // Passes in the data as a string.
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' }  // Set the headers so Angular passing info as form data (not request payload)
        })
             //Reloads the page after posting a new trip to the database:
            .then(function (data) {
                console.log(data);
                $route.reload();
            });
    };
});