app.service("APIService", function ($http) {
    this.getOwners = function () {
        return $http.get('http://localhost:62345/api/Owners')
    }

    this.getOwner = function (ownerId) {
        return $http.get('http://localhost:62345/api/Owners/' + ownerId)
    }

    this.postOwner = function (owner) {
        return $http(
            {
                method: 'post',
                data: owner,
                url: 'http://localhost:62345/api/Owners'
            }); 
    }

    this.deleteOwner = function (ownerID) {
        var url = 'http://localhost:62345/api/Owners/' + ownerID;
        return $http(
            {
                method: 'delete',
                data: ownerID,
                url: url
            });
    } 

    this.getPets = function (ownerId) {
        return $http.get('http://localhost:62345/api/Pets/' + ownerId)
    }

    this.postPet = function (pet){
        return $http(
            {
                method: 'post',
                data: pet,
                url: 'http://localhost:62345/api/Pets'
            })
    }

    this.deletePet = function (petID) {
        var url = 'http://localhost:62345/api/Pets/' + petID;
        return $http(
            {
                method: 'delete',
                data: petID,
                url: url
            });
    }   
});   