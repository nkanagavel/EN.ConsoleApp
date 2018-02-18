
var ENAngularModule = angular.module("ENAngularModule", ['ngRoute']);

//ENAngularModule.config(function ($routeProvider, $locationProvider) {
//    $locationProvider.html5Mode(true);
//    $routeProvider
//        .when('/', {
//            templateUrl: 'home/index',
//            controller: 'homecontroller'
//        })
//        .when('/home', {
//            templateUrl: 'home/index',
//            controller: 'homecontroller'
//        })
//        .when('/contact', {
//            templateUrl: 'home/contact'
//        })
//        .when('/about', {
//            name: 'about',
//            controller: 'aboutcontroller'
//        })
//        .otherwise({ redirectTo: '/home' });
//})


ENAngularModule.controller('homecontroller', function ($scope) {
    $scope.PageTitle = "Home";
    $scope.Title = "Contact";
})

ENAngularModule.controller('aboutcontroller', function ($scope) {
    $scope.PageTitle = "About";
})