(function () {

    "use strict";

    angular.module("app", ["ngRoute"])
    .config(function ($routeProvider) {

        $routeProvider.when("/", {
            controller:"vocabularyController",
            controllerAs: "vm",
            templateUrl:"/views/vocabView.html"
        });

        $routeProvider.when("/editor/:vocabTerm", {
            controller: "vocabularyEditorController",
            controllerAs: "vm",
            templateUrl: "/views/vocabularyEditorView.html"
        });
        $routeProvider.otherwise({ redirectTo: "/" });
});

})();