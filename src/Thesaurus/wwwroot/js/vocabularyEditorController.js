(function () {
    "use strict";

    angular.module("app")
    .controller("vocabularyEditorController", vocabularyEditorController)

    function vocabularyEditorController($routeParams,$http) {

        var vm = this;
        vm.vocabTerm = $routeParams.vocabTerm;
        vm.contextTerms = [];
        vm.errorMessage = "";
        vm.isBusy = true;
        vm.newContextTerm = {};
        var url = "/Vocabulary/" + vm.vocabTerm + "/contextTerms"

        $http.get(url)
        .then(function (response) {
            angular.copy(response.data, vm.contextTerms)
        }, function (err) {
            vm.errorMessage = "Failed to load context terms";

        })
        .finally(function () {
            vm.isBusy = false;
        });

        vm.addSynonym = function () {
            vm.isBusy = true;
            vm.errorMessage = "";

            $http.post(url, vm.newContextTerm)
            .then(function (response) {
                vm.contextTerms.push(response.data);
                vm.newContextTerm={};

            }),
            (function (err) {
                vm.errorMessage="Failed to add new synonym"

            })
            .finally(function () {
                vm.isBusy = false;
            });
        };

    }



})();