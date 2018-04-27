// add socket.io and pass work on port 3000
var io = require('socket.io')(process.env.PORT || 3000);
var randomWords = require('random-words');

console.log('Hi, World');

// count connected players
// var countPlayers = 0;

var users = [];

// Give random ID to players
//console.log(randomWords());

// pass parameter to socked.io, and callback as second parameter
io.on('connection', function(socket) {
    console.log('Spawn Player and Unity Connected');
    // give the random id
    var playerID = randomWords();
    // save objects about player
    // Creating object players
    var objectPlayer = {
        id: playerID,
        //position: {x: 0,y: 0}
        x: 0,
        y: 0
    };

    // push the playerID to array of users id's
    //users.push(playerID);
    //console.log('Player ID: ', playerID);

    // Creating a key [with player ID] inside player and set it to player
    users[playerID] = objectPlayer;
    console.log('Player Object: ', playerID);

    // adding locasl player to users list
    socket.emit('ukazanie', {
        id: playerID
    });


    // broadcasting "zaspawnitj" to all users
    socket.broadcast.emit('zaspawnitj', {
        id: playerID
    });
    // ask user for current possition
    socket.broadcast.emit('onlineposition');
    // add connected player
    //countPlayers++;
    for (var userID in users) {
        if (userID == playerID)
            continue;
        //connect new player
        // {id: userID}
        socket.emit('zaspawnitj', users[userID]);
        console.log('new players know zaspawnitj id:', userID);
    };

    // Find player in array
    //users.forEach(function(user) {
    // to dont make new player, check if player connected, dont connect twice
    //  if (user == playerID)
    //    return;
    // connect new player
    //  socket.emit('zaspawnitj', {
    //    id: user
    //  });
    //  console.log('new players know zaspawnitj id:', user);
    //});

    //for (i = 0; i < countPlayers; i++) {
    //  socket.emit('zaspawnitj');
    //  console.log('new players know zaspawnitj');
    //}

    // if user disconnected
    socket.on('disconnect', function() {
        console.log('player disconnect');
        // Remove the players with playerID from list
        // No longer in array, so this wil not work
        //users.splice(users.indexOf(playerID), 1);
        delete users[playerID];

        //countPlayers--;
        //Seng the action to delete user from game and telling who this player are
        socket.broadcast.emit('deleteplayer', {
            id: playerID
        });
    })

    socket.on('sledovanie', function(dannie) {
        console.log("Sledovatj zapros", dannie);
        // who is current player
        dannie.id = playerID;
        // let everyplayer know updated possition
        socket.broadcast.emit('sledovanie', dannie);
    })

    socket.on('newonlinepossition', function(dannie) {
        console.log("Online possition", dannie);
        // who is current player
        dannie.id = playerID;
        // let everyplayer know updated possition
        socket.broadcast.emit('newonlinepossition', dannie);
    })

    // if connected then lisen event "dvizhenie"
    socket.on('dvizenie', function(dannie) {
        // Adding the ID of player to passing data called "dannie"
        dannie.id = playerID;
        // Turn data in JSON to string
        console.log('User dvizhenie', JSON.stringify(dannie));
        // Refrence to a object players
        //objectPlayer.position.x = dannie.x;
        //objectPlayer.position.y = dannie.y;
        objectPlayer.x = dannie.x;
        objectPlayer.y = dannie.y;
        //console.log(objectPlayer);
        // pass data from player to all players with possition
        socket.broadcast.emit('dvizenie', dannie);
    })

    // to share attack
    socket.on('atakuem', function(data) {
        //console.log("atakuem", data);
        data.id = thisPlayerId;
        //console.log("atakuem", data.id);
        io.emit('atakuem', data);
    })

})