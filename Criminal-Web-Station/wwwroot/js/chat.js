"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message, userId) {
    //If change username input field is empty, it's displayed error message
    if (user == null || user == "") {
        var alertElement = document.getElementById('noUsernameError');
        alertElement.classList.remove('d-none');
        return;
    }

    //If change username input is not empty, we remove the error
    var alertElement = document.getElementById('noUsernameError');
    alertElement.classList.add('d-none');

    //and hide the change username input element
    var usernameInputEleemnt = document.getElementById('usernameContainerAndSubmitButton');
    usernameInputEleemnt.classList.add('d-none');

    //Here div element is created with user message and appended into message box
    var div = document.createElement("div");
    var currentdate = new Date();
    
    var time = currentdate.getHours() + ":"
        + currentdate.getMinutes() + ":" + currentdate.getSeconds();
    if (message == '') {
        message = '...';
    }
    div.innerHTML =
        `<div class="media w-50 mb-3">
                    <div>${user}</div>
                    <div class="media-body ml-3">
                        <div class="bg-light rounded py-2 px-3 mb-2">
                            <p class="text-small mb-0 text-muted">${message}</p>
                        </div>
                        <p class="small text-muted">Today - ${time}</p>
                    </div>
                </div>`;

    document.getElementById("messageBox__").appendChild(div);
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    var userId = document.getElementsByClassName("accountId__")[0].id;


    connection.invoke("SendMessage", user, message, userId).catch(function (err) {
        return console.error(err.toString());
    });
    //Clearing the message input field
    document.getElementById("messageInput").value = "";
    event.preventDefault();
});

document.getElementById('messageInput').addEventListener('keypress', function (event) {
    if (event.keyCode == 13) {
        var user = document.getElementById("userInput").value;
        var message = document.getElementById("messageInput").value;
        var userId = document.getElementsByClassName("accountId__")[0].id;


        connection.invoke("SendMessage", user, message, userId).catch(function (err) {
            return console.error(err.toString());
        });
        //Clearing the message input field
        document.getElementById("messageInput").value = "";
        var messageBox = document.getElementById('messageBox__');
        messageBox.scrollTop = messageBox.scrollHeight;

        event.preventDefault();
    }
})