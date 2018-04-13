app.controller('HandleVehicleController', function ($scope, $http, $route) {
    $scope.titleHandleVehicle = "Lägg till/Hantera fordon";
    $scope.addNewVehicleTitle = "Lägg till nytt fordon";
    $scope.formData = {};

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

    // Set status Activate on vehicle from the database:
    //$scope.activeVehicle = function (vehicle) {
    //$http({
    //    method: 'PUT',
    //    url: vehicleUrl + '/' + vehicle.VehicleId
    //}).then(function (data) {
    //    if (vehicle.activeVehicle === false) {
    //        vehicle.activeVehicle = true;
    //    }
    //    if (vehicle.activeVehicle === true) {
    //        vehicle.activeVehicle = false;
    //    }
    //})
    //    // Reloads the page after updating a vehicle from the database:
    //    .then(function (data) {
    //        console.log(data);
    //        $route.reload();
    //    });

    //};

    // Set status Inactive on vehcile from the database:
    //$scope.inactiveVehicle = function () {

    //};

    // Set status StandardVehicle on vehcile from the database:
        //$scope.standardVehicle = function () {

    //};
});