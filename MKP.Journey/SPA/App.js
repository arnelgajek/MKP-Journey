var app = angular.module("app", ['ngRoute']);

app.config(['$routeProvider',

    function ($routeProvider) {
        $routeProvider
            .when("/", {
                templateUrl: "/SPA/View/LoginView.html",
                controller: 'LoginController'
            })
            .when("/CreateAccount", {
                templateUrl: "/SPA/View/CreateAccountView.html",
                controller: 'CreateAccountController'
            })
            .when("/Summary", {
                templateUrl: "/SPA/View/SummaryView.html",
                controller: 'SummaryController'
            })
            .when("/NewJourney", {
                templateUrl: "/SPA/View/NewJourneyView.html",
                controller: 'NewJourneyController'
            })
            .when("/Report", {
                templateUrl: "/SPA/View/JourneyReportView.html",
                controller: 'JourneyReportController'
            })
            .when("/HandleVehicle", {
                templateUrl: "/SPA/View/HandleVehicleView.html",
                controller: 'HandleVehicleController'
            })
            .when("/ChatSupport", {
                templateUrl: "/SPA/View/ChatSupportView.html",
                controller: 'ChatSupportController'
            })
            .otherwise({
                redirectTo: "/"
            });
}]);
