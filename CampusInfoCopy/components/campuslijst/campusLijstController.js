/**
 * User Interfaces 3
 * Academiejaar 2014-2015
 */
"use strict";

var campusLijstController = angular.module('campusLijstController', []);

campusLijstController.controller('CampusLijstController', ['$scope', '$routeParams', '$location', 'Rooms', 'EigenschappenService',
        function ($scope, $routeParams, $location, Rooms, EigenschappenService) {
            $scope.rooms = Rooms.query();

            /*Experimenteel
            $scope.room = new Rooms(); //this object now has a $save() method
            $scope.addRoom = function () { //create a new movie. Issues a POST to /api/movies
                $scope.room.$save({type: 'campusdetail/rooms', roomId: $routeParams.roomId}, function () {
                    console.log('saved'); // on success go back to home i.e. movies state.
                });
            };*/

            $scope.browse = function (path) {
                $location.path(path);
                console.log(path);
            }

            $scope.verdieping1 = EigenschappenService.getVerdieping();
            $scope.verdiepingsno = EigenschappenService.getVerdiepingsno();

            $scope.layout = EigenschappenService.getLayout();
            $scope.setLayout = function () {
                return EigenschappenService.setLayout($scope.layout);
            }

            $scope.capaciteit = EigenschappenService.getCapaciteit();
            $scope.setCapaciteit = function () {
                return EigenschappenService.setCapaciteit($scope.capaciteit);
            }

            $scope.naam = EigenschappenService.getNaam();
            $scope.setNaam = function () {
                return EigenschappenService.setNaam($scope.naam);
            }

            $scope.lokaaltype = EigenschappenService.getLokaalType();
            $scope.setLokaalType = function () {
                return EigenschappenService.setLokaalType($scope.lokaaltype);
            }

            $scope.omschrijving = EigenschappenService.getOmschrijving();
            $scope.setOmschrijving = function () {
                return EigenschappenService.setOmschrijving($scope.omschrijving);
            }

            $scope.beameraanwezig = EigenschappenService.getBeamerAanwezig();
            $scope.setBeamerAanwezig = function () {
                return EigenschappenService.setBeamerAanwezig($scope.beameraanwezig);
            }

            $scope.acties = EigenschappenService.getActies();
            $scope.setActies = function () {
                return EigenschappenService.setActies($scope.acties);
            }

            $scope.actie = true;
            $scope.toonActiePaneel = function () {
                $scope.actie = !$scope.actie;
            };
        }
    ]
);