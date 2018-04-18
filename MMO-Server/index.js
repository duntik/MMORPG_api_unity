// Add socket.io and pass work on port 3000
var io = require('socket.io')(process.env.PORT || 3000);

console.log('Hello, server work');

// pass parameter to socked.io, and callback as second parameter
io.on('connection', function(socket) {
  console.log('Unity Connected');

  // if connected then lisen event "dvizhenie"
  socket.on('dvizenie', function(dannie) {
    console.log('User dvizhenie');
  })
})