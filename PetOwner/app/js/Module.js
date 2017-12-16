var app = angular.module('APIModule', ['ngRoute', 'ui.bootstrap'])
    .config(function ($routeProvider) {
        $routeProvider.when('/owners',
            {
                templateUrl: "app/views/owners.html",
                controller: "OwnersController"
            });
        $routeProvider.when("/owners/:id", {
            templateUrl: "app/views/pets.html",
            controller: "PetsController"
        });
        $routeProvider.otherwise({ redirectTo: '/owners' });
    });