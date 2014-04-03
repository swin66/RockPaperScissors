function gameController($scope, $http, toaster) {
    $scope.gameNumber = 0;
    $scope.player1Score = 0;
    $scope.player2Score = 0;
    $scope.gameTypes = [];
    $scope.moveNames = [];
    $scope.gameResult = null;
    $scope.game = {
        Player1Move: {
            PlayerType: 'computer',
            MoveName: ''
        },
        Player2Move: {
            PlayerType: 'computer',
            MoveName: ''
        }
    };
    
    $scope.postGame = function (game) {
        $scope.gameNumber++;
        $http.post('/api/game', game)
            .success(function(data) {
                $scope.gameResult = data;
                if ($scope.gameResult.WinningPlayerNumber == 1) $scope.player1Score++;
                if ($scope.gameResult.WinningPlayerNumber == 2) $scope.player2Score++;
                toaster.pop('note', "Game " + $scope.gameNumber + " Result", $scope.gameResult.Message);
            });
    };

    $scope.setPlayer2 = function (playerType) {
        $scope.game.Player2Move.PlayerType = playerType;
        $scope.game.Player2Move.MoveName = '';
    };
    
    $scope.setHumanMove = function (moveName) {
        $scope.game.Player2Move.MoveName = moveName;
    };

    $scope.setComputerMove = function(player) {
        $http.get('/api/game/moves/random')
            .success(function (data) {
                $scope.game[player].PlayerType = 'computer';
                $scope.game[player].MoveName = JSON.parse(data);
            });
    };

    var initialise = function() {
       
        $http.get('/api/game/types')
            .success(function(data) {
                 $scope.gameTypes = data;
            });
        
        $http.get('/api/game/moves')
            .success(function (data) {
                $scope.moveNames = data;
            });
    };

    initialise();
}