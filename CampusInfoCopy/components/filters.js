/**
 * User Interfaces 3
 * Academiejaar 2014-2015
 */
"use strict";

angular.module('campusFilters',[]).filter('checkmark',
    function() {
        return function(input) {
            return input ? '\u2713' : '\u2718';
/*            if(input==false){
                return '\u2718';
            }*/
        }
    }
);

