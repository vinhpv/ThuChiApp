angular.module('nguoithuchis', [])
    .controller('nguoithuchisCtrl', ['$scope', '$http', function ($scope, $http) {

        $scope.getAll = function () {
            $http.get('/api/nguoithuchis/GetNguoithuchis')
                .success(function (data, status, headers, config) {
                    $scope.Nguoithuchis = data;
                });
        }

        $scope.getOne = function (id) {
            $http.get('/api/nguoithuchis/GetNguoithuchis/' + id)
                .success(function (data, status, headers, config) {
                    $scope.Nguoithuchi = data;
                });
        }

        $scope.InsertNguoithuchi = function () {
            item =
                {
                    hovaten: $scope.hovaten,
                    ghichu: $scope.ghichu
                };

            if ($scope.hovaten != '') {
                $http.post('/api/nguoithuchis/PostNguoithuchi', item)
                    .success(function (data, status, headers, config) {
                        $scope.hovaten = '';
                        $scope.ghichu = '';
                        $scope.getAll();
                    });
            }
        }

        $scope.UpdateNguoithuchi = function (index) {
            item =
                {
                    hovaten: $scope.hovaten,
                    ghichu: $scope.ghichu
                };

            if ($scope.hovaten != '') {
                $http.put('/api/nguoithuchis/PutNguoithuchi/' + $scope.Nguoithuchis[index].nguoithuchi_id, item)
                    .success(function (data, status, headers, config) {
                        $scope.getAll();
                    });
            }
        }

        $scope.DeleteNguoithuchi = function (index) {
            $http.delete('/api/nguoithuchis/' + $scope.Nguoithuchis[index].nguoithuchi_id)
                    .success(function (data, status, headers, config) {
                        $scope.getAll();
                    });
        }

        $scope.getAll();
    }]);
