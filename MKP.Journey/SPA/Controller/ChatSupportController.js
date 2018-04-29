app.controller('ChatSupportController', function ($scope, $location) {
    $scope.titleChatSupport = "Support - Chatta med oss";

    if (localStorage.getItem("bearer") === null) {
        $location.path('/');
    }
});