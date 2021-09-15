"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:5001/NotificationHub").build();

connection.on("sendNotification" , user => {
     LoadData();
     toastr.success(user.split(' ')[0] + ' joined the group')
});
connection.start().catch(function (err) {
     return console.error(err.toString());
});