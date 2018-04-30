app.controller('HandleVehicleController', function ($scope, $http, $route, $location) {
    $scope.titleHandleVehicle = "Lägg till/Hantera fordon";
    $scope.addNewVehicleTitle = "Lägg till nytt fordon";
    $scope.formData = {};
    $scope.statusButton = 'Status';

    var vehicleUrl = "http://localhost:53201/api/vehicle";

    if (localStorage.getItem("bearer") === null) {
        $location.path('/');
    }

    // Retrieves vehicles from the database:
    $http.get(vehicleUrl, { headers: { 'Authorization': 'Bearer ' + localStorage.getItem('bearer') } // Gives you the authorization to get all the vehicles from db.
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
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded', // Set the headers so Angular passing info as form data (not request payload)
                'Authorization': 'Bearer ' + localStorage.getItem('bearer')} // Gives you the authorization to add a new vehicle.
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
            url: vehicleUrl + '/' + vehicle.Id
        })
            // Reloads the page after deleting a vehicle from the database:
            .then(function (data) {
                console.log(data);
                $route.reload();
            });
    };

     //Set status Activate on vehicle from the database:
    $scope.setStatus = function (vehicle) {

            // Fordonstatus:
            if (vehicle.Status === 0) {
                vehicle.Status = 1;
                //vehicleStatus.isDisabled = true;
                //$scope.vehicleBtnName[1] = 'Inactivate';
            } else {
                vehicle.Status = 0;
                //vehicleStatus.isDisabled = false;
                //$scope.vehicleBtnName[1] = 'Activate';
            }


            // Send the value (true/false) to the API:
            $http({
                method: 'PUT',
                url: vehicleUrl + '/' + vehicle.Id,
                data: vehicle,
                headers: {
                    'Content-Type': 'application/json'
                }
            });
            console.log(vehicle);
        };

    // Set status StandardVehicle on vehcile from the database:
        //$scope.standardVehicle = function () {

    //};
});