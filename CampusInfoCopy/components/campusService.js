/**
 * User Interfaces 3
 * Academiejaar 2014-2015
 */
"use strict";

var campusServices = angular.module('campusService', ['ngResource']);

campusServices.factory('Rooms', ['$resource',
        function ($resource) {
            return $resource('components/:type/:roomId.json', {}, {
                query: {method: 'GET', params: {type: 'campuslijst', roomId: 'rooms'}, isArray: true}
                //roomdetail: {method: 'GET', params: {type: 'campusdetail/rooms'}, isArray: false}
                //extra actions
            });
        }
    ]
);