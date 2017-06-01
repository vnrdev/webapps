/**
 * User Interfaces 3
 * Academiejaar 2014-2015
 */
"use strict";

var campusDetailController = angular.module('campusDetailController', []);

campusDetailController.controller('CampusDetailController', ['$scope', '$routeParams', 'Rooms', 'EigenschappenService',
        function ($scope, $routeParams, Rooms, EigenschappenService) {

            //Add extra functions
            $scope.tbd = EigenschappenService.getTbd();
            //$scope.capaciteit = EigenschappenService.getCapaciteit();

            $scope.room = Rooms.get({type: 'campusdetail/rooms', roomId: $routeParams.roomId},function(room){
             //set scope variable $scope.roomproperty = room.property (array: room.property[i])
             });
        }
    ]
);