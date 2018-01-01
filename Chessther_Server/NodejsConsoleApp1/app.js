var net = require('net');
var colors = require("chalk");
var server = net.createServer();
var clients=[];
var clientsNum=0;
var clientsName=[];

server.on("connection", function (socket) {
    clients.push(socket);
    clientsNum++;
    var remoteAddress = socket.remoteAddress + socket.remotePort;
    console.log("new client is made %s", remoteAddress);

    socket.on("data",function(d) {
        console.log("Data from %s: %s", remoteAddress, d);
        d=d.toString();
        router(d, socket);
    });
    socket.once("close", function () {
        clients.splice(clients.indexOf(socket), 1);
        clientsNum--;
        SendAll(onlineList());
        console.log("connection from %s is closed.", remoteAddress);
    });
    socket.on("error", function (err) {
        console.log("connection from %s has error: %s", remoteAddress, err.message);
    });

});

server.listen(9000, function () {
    console.log("server is listening to %j", server.address());
});

function router(d, socket){
    var data=d;
    data=data.slice(1,data.length);

    switch(d.charAt(0)){
        case '0':       //連上伺服器，傳入名稱
            socket.name=data;
            SendAll(onlineList());
            socket.write("M"+"Hello "+ socket.name+", Welcome to CHESSther, please only type English OAO ");
            break;
        case '1':
            SendAll(d);
            //socket.write("M"+"You just said: "+data+" in public.");
            break;
        case '2':
            var C= data.split("|");
            SendTo(d[0]+C[0],C[1]);
            break;
        case '3':       //收到邀請
            var C= data.split("|");
            if(clients[findSocket(C[1]).opponent]==null)
                SendTo(d[0]+C[0]+"|"+C[1],C[1]);
            else
                SendTo("2"+"Sorry, "+C[1]+" is busy playing with others", C[0]);
            break;
            
        case '4':       //同意對戰請求
            var C= data.split("|");
            clients[findSocket(C[0])].opponent=C[1];
            clients[findSocket(C[1])].opponent=C[0];
            SendTo(d[0]+C[0], C[1]);
        case '5':
            var C = data.split("|");
            SendTo(d,C[0]);
            break;
        
    }
}

function findSocket(name){
    var id=-1;
    for(i=0; i<clients.length; i++){
        if(clients[i].name==name){
            id=i;
            break;
        }
    }
    return id;
}

//sendAll include sending a message to itself
function SendAll(message){
    clients.forEach(function(client){
        client.write(message);
    });
}
function SendTo(message, player){
    var playerID=findSocket(player);
    clients[playerID].write(message);
}

function onlineList(){
    var L = "L";
    for(i=0; i<clients.length; i++){
        L += clients[i].name;
        if(i<clients.length-1){L += ",";}
    }
    return L;
}