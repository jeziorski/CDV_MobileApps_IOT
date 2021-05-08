(function () {
    var txtMessage = $('#txtMessage')
    var btnSend = $('#btnSend')
    var listMessages = $('#listMessages')
    var connection = new signalR.HubConnectionBuilder().withUrl('/chathub').build();
    var userName = $('#userName').val();

    $(btnSend).click(function () {
        var userMessage = $(txtMessage).val();

        connection.invoke('SendMessage', {
            userName: userName,
            message: userMessage
        }).catch(function (error) {
            alert("Can't send the message");
            console(error);
        })
        $(txtMessage).val('');
    });

    connection.start().then(function () {
        console.log('Connected to the signalr hub');
        $(btnSend).removeAttr('disabled');
    })

    connection.on('ReceiveMessage', function (obj) {
        $(listMessages).prepend('<li>'
            + '<span class="badge bg-primary">'+ obj.timeStampString + '</span>'
            + '<span class="badge bg-info text-dark font-weight-bold">' + obj.username
            + '</span><br/>' + obj.message
            + '</li>' )
    })
})();