const WebSocket = require('ws');

const wss = new WebSocket.Server({ port: 8080 });
const wss2 = new WebSocket.Server({ port: 5052 });

let data = '';

wss.on('connection', function connection(ws) {
  console.log('A new client connected on 8080!');

  ws.on('message', function incoming(message) {
    data = message;
    console.log('Received on 8080 and sending to all clients on 5052: %s', data);

    // Broadcast to all clients connected to wss2
    wss2.clients.forEach(function each(client) {
      if (client.readyState === WebSocket.OPEN) {
        client.send(data);
      }
    });
  });

  // Send a welcome message to the client
  ws.send('Welcome to the WebSocket server!');
});

wss2.on('connection', function connection(ws) {
  console.log('A new client connected on 5052!');

  // Optionally, if you want to send existing data immediately upon a new connection
  if (data && ws.readyState === WebSocket.OPEN) {
    console.log('Sending existing data to a newly connected client on 5052: %s', data);
    ws.send(data);
  }
});

console.log('WebSocket servers started on ws://localhost:8080 and ws://localhost:5052');