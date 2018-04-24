app.controller('NewJourneyController', function ($scope, $http, $route, $location) {
    $scope.titleNewJourney = "Registrera ny resa";
    $scope.formData = {};

    var tripUrl = "http://localhost:53201/api/trips";

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
                            $scope.trip.stopAddress = results[0].formatted_address;
                            $scope.$apply();
                            console.log($scope.trip.stopAddress);
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

    // Post new trip to the database:
    $scope.newTrip = function (trip) {
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