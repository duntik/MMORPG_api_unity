// add socket.io and pass work on port 3000
var io = require('socket.io')(process.env.PORT || 3000);

console.log('Hello, server work');

// count connected players
var countPlayers = 0;

// pass parameter to socked.io, and callback as second parameter
io.on('connection', function(socket) {
  console.log('Spawn Player and Unity Connected');

  // broadcasting "zaspawnitj" to all users
  socket.broadcast.emit('zaspawnitj');
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
    console.log('User dvizhenie');
  })

})