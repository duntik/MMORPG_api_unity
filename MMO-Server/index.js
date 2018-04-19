// add socket.io and pass work on port 3000
var io = require('socket.io')(process.env.PORT || 3000);
var randomWords = require('random-words');

console.log('Hello, server work');

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

  // push the playerID to array of users id's
  users.push(playerID);
  console.log('Player ID: ', playerID);

  // broadcasting "zaspawnitj" to all users
  socket.broadcast.emit('zaspawnitj', {
    id: playerID
  });
  // ask user for current possition
  socket.broadcast.emit('onlineposition');
  // add connected player
  //countPlayers++;

  //
  users.forEach(function(user) {
    // to dont make new player, check if player connected, dont connect twice
    if (user == playerID)
      return;
    // connect new player
    socket.emit('zaspawnitj', {
      id: user
    });
    console.log('new players know zaspawnitj id:', user);
  });

  //for (i = 0; i < countPlayers; i++) {
  //  socket.emit('zaspawnitj');
  //  console.log('new players know zaspawnitj');
  //}

  // if user disconnected
  socket.on('disconnect', function() {
    console.log('player disconnect');
    // Remove the players with playerID from list
    users.splice(users.indexOf(playerID), 1);
    //countPlayers--;
    //Seng the action to delete user from game and telling who this player are
    socket.broadcast.emit('deleteplayer', {
      id: playerID
    });
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
    // pass data from player to all players with possition
    socket.broadcast.emit('dvizenie', dannie);
  })

})