"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/myHub").build();

connection.on("ReceiveMessage", function (message) {
        document.getElementById("messagesList").innerHTML = "- "+message+" +";             
});


connection.start().then(function () {

}).catch(function (err) {
    return console.error(err.toString());
});

