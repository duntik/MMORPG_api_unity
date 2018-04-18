// add socket.io and pass work on port 3000
var io = require('socket.io')(process.env.PORT || 3000);
var randomWords = require('random-words');

console.log('Hello, server work');

// count connected players
var countPlayers = 0;

// Give random ID to players
//console.log(randomWords());

// pass parameter to socked.io, and callback as second parameter
io.on('connection', function(socket) {
  console.log('Spawn Player and Unity Connected');
  var playerID = randomWords();
  console.log('Player ID: ', playerID);

  // broadcasting "zaspawnitj" to all users
  socket.broadcast.emit('zaspawnitj', {
    id: playerID
  });
  // add connected player
  countPlayers++;

  for (i = 0; i < countPlayers; i++) {
    socket.emit('zaspawnitj');
    console.log('new players know zaspawnitj');
  }

  // if user disconnected
  socket.on('disconnect', function() {
    console.log('player disconnect');
    countPlayers--;
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