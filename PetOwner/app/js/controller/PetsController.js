app.controller('PetsController', function ($scope, APIService, $routeParams) {

    //parameter for sorting order(ascending, descending)
    $scope.reverse = true;
    //property name that used for sorting
    $scope.propertyName;

    //default page number
    $scope.currentPage = 1;
    //number of items per page
    $scope.itemsPerPage = 3;

    $scope.petsCount;

    getPetById($routeParams.id);

    function getPetById(ownerId) {
        var servOwner = APIService.getOwner(ownerId);
        servOwner.then(function (d) {
            $scope.owner = d.data;
        }, function (error) {
            $log.error('Oops! Something went wrong while fetching the data.')
        })
        var servPets = APIService.getPets(ownerId);
        servPets.then(function (d) {
            $scope.pets = d.data;
            $scope.petsCount = $scope.pets.length;
        }, function (error) {
            $log.error('Oops! Something went wrong while fetching the data.')
        })
    }

    $scope.postPet = function () {
        var pet = {
            Name: $scope.petname,
            OwnerId: $routeParams.id,
        };
        var savePet = APIService.postPet(pet);
        savePet.then(function (d) {
            getPetById($routeParams.id);
        }, function (error) {
            console.log('Oops! Something went wrong while saving the data.')
        })
    }; 

    $scope.deletePet = function (petId) {
        var dlt = APIService.deletePet(petId);
        dlt.then(function (d) {
            getPetById($routeParams.id);
        }, function (error) {
            console.log('Oops! Something went wrong while deleting the data.')
        })
    }

    $scope.sortBy = function (propertyName) {
        $scope.reverse = ($scope.propertyName === propertyName) ? !$scope.reverse : false;
        $scope.propertyName = propertyName;
    };
})   