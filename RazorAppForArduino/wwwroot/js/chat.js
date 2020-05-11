"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/myHub").build();

connection.on("ReceiveMessage", function (message) {
    //var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var li = document.createElement("label");
    li.textContent = message;
    function setBoost(li, callback) {
        document.getElementById("messagesList").appendChild(li);
        callback();
    }
    setBoost(li, 
    setTimeout(function () {
        window.location.reload(1);
   }, 1000))        
});


connection.start().then(function () {

}).catch(function (err) {
    return console.error(err.toString());
});

