let hubUrl = 'https://84.201.131.165/chat'; //ссылка, по которому будем обращаться к хабу
let connection = new signalR.HubConnectionBuilder()  //строим соединение с хабом
    .withUrl(hubUrl)                      // в нашем случае будет использована технология web-socket
    .build();

//здесь мы задаем функцию, в которую будет отправлять новые данные хаб
connection.on('Send', function (name, message) {//первый параметр дублирует имя в методе отсылки хаба
    // в функции параметры - параметры, которые мы ожидаем получить от хаба
    $('#content').append(`<p><b>${name}: </b> ${message}</p>`); //вставляем на страницу наши сообщения

});
connection.start(); // с этого момента мы пытаемся наладить соединение

$('#sendMsg').click(function () {
    // при клике на кнопку отсылаем сообщение
    let txt = $('#text').val(); // вытаскиваем текст сообщения
    let name = $('#name').val(); // вытаскиваем имя
    $('#text').val(''); // обнуляем текст сообщения
    $.ajax(
        {
            type: 'POST',
            url: 'https://84.201.131.165/api/chat/send',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: `{ "text": "${txt}", "name": "${name}" }`,
            success: function (data, textStatus) {
                console.log(data); //выведем в консоль результат
            }
        });
});