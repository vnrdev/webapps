/**
 * User Interfaces 3
 * Academiejaar 2014-2015
 */
"use strict";

var EigenschappenService = angular.module('EigenschappenService',[]);

EigenschappenService.factory('EigenschappenService',
        function EigenschappenService() {
            var verdieping1 = 'verdieping';
            var verdiepingsno = 0;

            var naam = true;
            var capaciteit = true;
            var lokaaltype = false;
            var omschrijving = false;
            var beameraanwezig = false;
            var acties = false;

            var layout = 'grid';
            var tbd = 'to be done';
            //var theRoom = 'abc';
            var id = 0;

            return {
                getVerdieping: function () {
                    return verdieping1;
                },
                getVerdiepingsno: function() {
                    return verdiepingsno;
                },
                getTbd: function(){
                    return tbd;
                },
                getCapaciteit: function(){
                    return capaciteit;
                },
                setCapaciteit: function(bool){
                    capaciteit = bool;
                    console.log("capaciteit set to: " + bool);
                },
                getLayout: function(){
                    return layout;
                },
                setLayout: function(layoutType){
                    layout = layoutType;
                    console.log("layout set to: " + layoutType);
                },
                getRoom: function(){
                    return theRoom;
                },
                setRoom: function(room){
                    theRoom = room;
                },
                getId: function(){
                    return id;
                },
                setId: function(theId){
                    id=theId;
                    console.log("my id set to: "+theId);
                },
                getNaam: function(){
                    return naam;
                },
                setNaam: function(theNaam){
                    naam = theNaam;
                },
                getLokaalType: function(){
                    return lokaaltype;
                },
                setLokaalType: function(theLokaalType){
                    lokaaltype = theLokaalType;
                    console.log("lokaaltype set to: "+theLokaalType);
                },
                getOmschrijving: function(){
                    return omschrijving;
                },
                setOmschrijving: function(omschr){
                    omschrijving = omschr;
                },
                getBeamerAanwezig: function(){
                    return beameraanwezig;
                },
                setBeamerAanwezig: function (aanwezig) {
                    beameraanwezig = aanwezig;
                },
                getActies: function(){
                    return acties;
                },
                setActies: function(theActies){
                    acties = theActies;
                }

            };
        }
);
