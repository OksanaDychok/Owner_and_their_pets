app.controller('OwnersController', function ($scope, APIService) {

    //parameter for sorting order(ascending, descending)
    $scope.reverse = true;
    //property name that used for sorting
    $scope.propertyName;

    //default page number
    $scope.currentPage = 1;
    //number of items per page
    $scope.itemsPerPage = 3;

    $scope.ownerCount;
    $scope.owners;

    getAll();

    function getAll() {
        var servCall = APIService.getOwners();
        servCall.then(function (d) {
            $scope.owners = d.data;
            $scope.ownerCount = $scope.owners.length;
        }, function (error) {
                $log.error('Oops! Something went wrong while fetching the data.')
            })
    };

    $scope.postOwners = function () {
        var owner = {
            Name: $scope.ownername,
        };
        var saveOwner = APIService.postOwner(owner);
        saveOwner.then(function (d) {
            getAll();
        }, function (error) {
                console.log('Oops! Something went wrong while saving the data.')
            })
    }; 

    $scope.deleteOwner = function (ownerId) {
        var dlt = APIService.deleteOwner(ownerId);
        dlt.then(function (d) {
            getAll();
        }, function (error) {
            console.log('Oops! Something went wrong while deleting the data.')
        })
    };

    $scope.sortBy = function (propertyName) {
        $scope.reverse = ($scope.propertyName === propertyName) ? !$scope.reverse : false;
        $scope.propertyName = propertyName;
    };
})   