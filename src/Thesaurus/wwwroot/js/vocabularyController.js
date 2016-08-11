(function () {
    "use strict";

    angular.module("app")
    .controller("vocabularyController", vocabularyController)

    function vocabularyController($http) {

        var vm = this;

        vm.term = [];

        vm.newVocab = {};

        vm.errorMessage = "";

        vm.isBusy = true;

        $http.get("/Vocabulary")
        .then(function (response) {
            angular.copy(response.data, vm.term);

        }, function (error) {
            vm.errorMessage = "Failed to load data: " + error;

        })
        .finally(function () {

           vm.isBusy = false;
        });

        vm.addVocab = function () {
            vm.isBusy = true;
            vm.errorMessage = "";


            $http.post("/Vocabulary", vm.newVocab)
            .then(function (response) {
                vm.term.push(response.data);
                vm.newVocab = {};
            },
            function () {
                vm.errorMessage = "Failed to save new vocabulary term";
            })
            .finally(function(){
                vm.isBusy=false;
            });
        };
    }


})();