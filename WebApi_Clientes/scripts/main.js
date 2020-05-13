$(function () {
    $('#btnLogin').click(function () { loginUsuario(); });
});

function ajax(strUsuario,strClave, strFecha) {
    var result;
    var usuario = {};
    usuario.User = strUsuario;
    usuario.Clave = strClave;
    usuario.FechaLogin = strFecha;

    $.ajax({
        url: 'http://localhost:6030/api/login',
        type: 'POST',
        data: usuario,
        async: false
    }).done(function (data) {
        result = data;
    }).error(function (xhr, status, error) {
        alert(error);
        var s = status;
        var e = error;
    });

    return result;
}

function loginUsuario() {
    var usuario = $("#txtUsuario").val();
    var clave = $("#txtClave").val();
    
    var d = new Date();

    var month = d.getMonth() + 1;
    var day = d.getDate();

    var output = d.getFullYear() + '/' +
        (month < 10 ? '0' : '') + month + '/' +
        (day < 10 ? '0' : '') + day;


    var result = ajax(usuario, clave, output);
    alert(result);
}

