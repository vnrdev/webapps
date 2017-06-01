/**
 * User Interfaces 3
 * Academiejaar 2014-2015
 */
"use strict";

var campusInfoApp = angular.module('campusInfoApp', [
    'ngRoute',
    'ngAnimate',
    'campusLijstController',
    'campusDetailController',
    'ui.unique',
    'angular.filter',
    'campusFilters',
    'campusService',
    'EigenschappenService',
    'angularTranslate'
]);

campusInfoApp.config(['$routeProvider',
    function ($routeProvider) {
        $routeProvider.
            when('/campus', {
                templateUrl: 'components/campuslijst/campus-lijst.html',
                controller: 'CampusLijstController'
            }).
            when('/campus/rooms/:roomId', {
                templateUrl: 'components/campusdetail/campus-detail.html',
                controller: 'CampusDetailController'
            }).
            otherwise({
                redirectTo: '/campus'
            });
    }
]);