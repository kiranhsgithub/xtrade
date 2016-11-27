app = angular.module('XTradeApp');
app.controller('ItemController', ['$scope', function ($scope) {
    $scope.images = [{
        name: "UploadImage1"
    }];


    $scope.addImage = function () {

        let length = $scope.images.length;
        $scope.images.push({
            name: "UploadImage" + length
        });
    };

    $scope.removeImage = function (name) {
        let index = _.findIndex($scope.images, {
            name: name
        });

        $scope.images.splice(index, 1);
    };
}]);