app.controller('HandleVehicleController', function ($scope, $http, $route) {
    $scope.titleHandleVehicle = "Lägg till/Hantera fordon";
    $scope.addNewVehicleTitle = "Lägg till nytt fordon";
    $scope.formData = {};
    $scope.statusButton = 'Status';

    var vehicleUrl = "http://localhost:53201/api/vehicle";

    // Retrieves data from the database:
    $http({
        method: 'GET',
        url: vehicleUrl
    }).then(function (response) {
        $scope.vehicles = response.data;
    }, function (error) {
        console.log(error);
    });

    // Post new vehicle to the database:
    $scope.addVehicle = function () {
        $http({
            method: 'POST',
            url: vehicleUrl,
            data: $.param($scope.formData),  // Passes in the data as a string.
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' }  // Set the headers so Angular passing info as form data (not request payload)
        })
            // Reloads the page after posting a new vehicle to the database:
            .then(function (data) {
                console.log(data);
                $route.reload();
            });
    };

    // Delete vehicle from the database:
    $scope.deleteVehicle = function (vehicle) {
        $http({
            method: 'DELETE',
            url: vehicleUrl + '/' + vehicle.VehicleId
        })
            // Reloads the page after deleting a vehicle from the database:
            .then(function (data) {
                console.log(data);
                $route.reload();
            });
    };

     //Set status Activate on vehicle from the database:
    $scope.setStatus = function (vehicle) {

            // Send the value (true/false) to the API:
            $http({
                method: 'PUT',
                url: vehicleUrl + '/' + vehicle.VehicleId,
                data: vehicle,
                headers: {
                    'Content-Type': 'application/json'
                }
            }).then(function (data) {
                if (vehicle.Status === 0) {
                    vehicle.Status = 1;
                    vehicle.disableOrNot = false;
                    $scope.statusButton = 'Inactivate';
                } else {
                    vehicle.Status = 0;
                    vehicle.disableOrNot = true;
                    $scope.statusButton = 'Activate';
                    
                }
            });
            console.log(vehicle);
        };

    // Set status StandardVehicle on vehcile from the database:
        //$scope.standardVehicle = function () {

    //};
});